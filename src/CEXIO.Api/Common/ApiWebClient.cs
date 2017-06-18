using CEXIO.Api.Exceptions;
using CEXIO.Api.MarketEntities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CEXIO.Api.Common
{
    sealed class ApiWebClient
    {
        private string _baseUrl = "https://cex.io/api/";
        public string BaseUrl
        {
            get => _baseUrl;
            set
            {
                if (!value.EndsWith("/"))
                    value += "/";

                _baseUrl = value;
            }
        }

        private ApiCredentials _credentials;
        public ApiCredentials Credentials
        {
            get => _credentials;
            set => _credentials = value;
        }

        public ApiWebClient()
        {

        }

        public ApiWebClient(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public async Task<TEntity> GetDataAsync<TEntity>(string command, CancellationToken? cancellationToken = null)
            where TEntity : EntityBase
        {
            var relativeUrl     = CreateRelativeUrl(command);
            var result          = await GetFromServiceAsync<TEntity>(relativeUrl, cancellationToken);

            return result;
        }

        public async Task<TEntity> PostDataAsync<TEntity>(string command, Dictionary<string, string> paramFact, CancellationToken? cancellationToken = null)
            where TEntity : EntityBase
        {
            var relativeUrl = CreateRelativeUrl(command);
            var result      = await PostToServiceAsync<TEntity>(relativeUrl, paramFact, cancellationToken);

            return result;
        }

        private string CreateRelativeUrl(string command)
        {
            if (!command.EndsWith("/"))
                command += "/";

            string relativeUrl = string.Empty;

            relativeUrl += BaseUrl + string.Join("/", command);

            return relativeUrl;
        }

        private async Task<TEntity> GetFromServiceAsync<TEntity>(string command, CancellationToken? cancellationToken = null)
            where TEntity : EntityBase
        {
            using (var client = CreateHttpClient())
            using (var response = await (cancellationToken.HasValue ? client.GetAsync(command, cancellationToken.Value) : client.GetAsync(command)))
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TEntity>(json);

                return result;
            }
        }

        private async Task<TEntity> PostToServiceAsync<TEntity>(string command, Dictionary<string, string> paramFact, CancellationToken? cancellationToken = null)
            where TEntity : EntityBase
        {
            long nonce;
            var signature = Credentials.GenerateSignature(out nonce);

            var parameters = new Dictionary<string, string>()
            {
                    { "key", Credentials.ApiKey },
                    { "signature", signature },
                    { "nonce", nonce.ToString() }
            };

            if (paramFact != null)
                parameters = parameters.Concat(paramFact).ToDictionary(x => x.Key, x => x.Value);

            var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");

            using (var client = CreateHttpClient())
            using (var response = await (cancellationToken.HasValue ? client.PostAsync(command, content, cancellationToken.Value) : client.PostAsync(command, content)))
            {
                var json = await response.Content.ReadAsStringAsync();

                var errorObj = JObject.Parse(json);

                ThrowIfError(response, errorObj);

                var result = JsonConvert.DeserializeObject<TEntity>(json);
                return result;
            }
        }

        private HttpClient CreateHttpClient(TimeSpan? timeOut = null)
        {
            var client = new HttpClient(new HttpClientHandler()
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
            });

            client.MaxResponseContentBufferSize = Int32.MaxValue;

            if (timeOut != null)
                client.Timeout = timeOut.Value;

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private static void ThrowIfError(HttpResponseMessage response, JObject errorObj)
        {
            string[] knownErrors =
                {
                    "Invalid API key",
                    "Nonce must be incremented",
                    "Permission denied"
                };

            var error = errorObj["error"].ToString();

            switch (error)
            {
                case "Invalid API key":
                    throw new InvalidApiKeyException(response, error);

                case "Nonce must be incremented":
                    throw new NonceException(response, error);

                case "Permission denied":
                    throw new PermissionDeniedException(response, error);
            }

        }

    }
}
