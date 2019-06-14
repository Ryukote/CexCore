using CexCore.Common;
using CexCore.Contracts;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CexCore.Utilities
{
    /// <summary>
    /// Cex http client.
    /// </summary>
    public class CexHttpClient : ICexHttpClient
    {
        /// <summary>
        /// Calling GET endpoints on cex.io
        /// </summary>
        /// <returns>Tuple that represents HttpStatusCode and response content from called endpoint.</returns>
        /// <param name="url">Absolute url of the endpoint.</param>
        public async Task<Tuple<HttpStatusCode, string>> GetAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);

                    var responseContent = await response.Content.ReadAsStringAsync();

                    return new Tuple<HttpStatusCode, string>(response.StatusCode, responseContent);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException(CexExceptionMessages.HttpGetRequestException, ex);
            }
        }

        /// <summary>
        /// Calling POST endpoints on cex.io
        /// </summary>
        /// <returns>Tuple that represents HttpStatusCode and response content from called endpoint.</returns>
        /// <param name="url">Absolute url of the endpoint.</param>
        /// <param name="httpContent">Valid HTTP content.</param>
        public async Task<Tuple<HttpStatusCode, string>> PostAsync(string url, HttpContent httpContent)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    httpContent.Headers.ContentType.MediaType = "application/json";

                    var response = await client.PostAsync(url, httpContent);

                    var responseContent = await response.Content.ReadAsStringAsync();

                    return new Tuple<HttpStatusCode, string>(response.StatusCode, responseContent);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException(CexExceptionMessages.HttpPostRequestException, ex);
            }
        }
    }
}
