using CexCore.Exceptions;
using CexCore.MarketEntities;
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

namespace CexCore.Common
{
    public sealed class ApiWebClient
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
            var relativeUrl = CreateRelativeUrl(command);
            var result = await GetFromServiceAsync<TEntity>(relativeUrl, cancellationToken);

            return result;
        }

        public async Task<JObject> GetDataAsync(string command, CancellationToken? cancellationToken = null)
        {
            var relativeUrl = CreateRelativeUrl(command);

            using (var client = CreateHttpClient())
            {
                using (var response = await (cancellationToken.HasValue ? client.GetAsync(relativeUrl, cancellationToken.Value) : client.GetAsync(command)))
                {
                    var json = await response.Content.ReadAsStringAsync();

                    var result = JObject.Parse(json);

                    ThrowIfError(response, result);

                    return result;
                }
            }
        }

        public async Task<TEntity> PostDataAsync<TEntity>(string command, Dictionary<string, string> paramFact, CancellationToken? cancellationToken = null)
            where TEntity : EntityBase
        {
            var relativeUrl = CreateRelativeUrl(command);
            var result = await PostToServiceAsync<TEntity>(relativeUrl, paramFact, cancellationToken);

            return result;
        }

        public async Task<string> PostDataAsync(string command, Dictionary<string, string> paramFact, CancellationToken? cancellationToken = null)
        {
            var relativeUrl = CreateRelativeUrl(command);
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            try
            {
                var signature = Credentials.GenerateSignature(out long nonce);

                var authParams = new Dictionary<string, string>()
                {
                    { "key", Credentials.ApiKey },
                    { "signature", signature },
                    { "nonce", nonce.ToString() }
                };

                parameters = parameters.Concat(authParams).ToDictionary(x => x.Key, x => x.Value);
            }
            catch (NullReferenceException)
            {

            }

            if (paramFact != null)
                parameters = parameters.Concat(paramFact).ToDictionary(x => x.Key, x => x.Value);

            var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");

            using (var client = CreateHttpClient())
            using (var response = await (cancellationToken.HasValue ? client.PostAsync(relativeUrl, content, cancellationToken.Value) : client.PostAsync(relativeUrl, content)))
            {
                var json = await response.Content.ReadAsStringAsync();

                if (json == "true")
                    return json;

                JObject errorObj = null;

                try
                {
                    errorObj = JObject.Parse(json);
                }
                catch (JsonReaderException ex)
                {
                    string error = "Error reading JObject from JsonReader. Current JsonReader item is not an object: StartArray. Path '', line 1, position 1.";

                    if (ex.Message == error)
                        return json;

                    throw;
                }

                ThrowIfError(response, errorObj);


                return json;
            }
        }

        private async Task<TEntity> GetFromServiceAsync<TEntity>(string command, CancellationToken? cancellationToken = null)
            where TEntity : EntityBase
        {
            using (var client = CreateHttpClient())
            {
                using (var response = await (cancellationToken.HasValue ? client.GetAsync(command, cancellationToken.Value) : client.GetAsync(command)))
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TEntity>(json);

                    return result;
                }
            }
        }

        private async Task<TEntity> PostToServiceAsync<TEntity>(string command, Dictionary<string, string> paramFact, CancellationToken? cancellationToken = null)
            where TEntity : EntityBase
        {
            var signature = Credentials.GenerateSignature(out long nonce);

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
            })
            {
                MaxResponseContentBufferSize = Int32.MaxValue,
                BaseAddress = new Uri(BaseUrl)
            };

            if (timeOut != null)
                client.Timeout = timeOut.Value;

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private string CreateRelativeUrl(string command)
        {
            if (!command.EndsWith("/") && !command.Contains('?'))
            {
                command += "/";
            }

            string relativeUrl = string.Empty;

            relativeUrl += BaseUrl + string.Join("/", command);

            return relativeUrl;
        }

        private static void ThrowIfError(HttpResponseMessage response, JObject errorObj)
        {
            string[] knownErrors =
                {
                    "Invalid API key",
                    "API key is missing.",
                    "Nonce must be incremented",
                    "Permission denied",
                };

            var error = errorObj["error"];

            if (error == null)
                return;

            switch (error.ToString())
            {
                case "Invalid API key":
                    throw new InvalidApiKeyException(response, error.ToString());

                case "API key is missing.":
                    throw new ApiKeyIsMissingException(response, error.ToString());

                case "Nonce must be incremented":
                    throw new NonceException(response, error.ToString());

                case "Permission denied":
                    throw new PermissionDeniedException(response, error.ToString());

                default:
                    throw new ApiException(response, error.ToString());
            }

        }

    }
}
