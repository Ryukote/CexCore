using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CexCore.Contracts;

namespace CexCore.Helpers
{
    /// <summary>
    /// Cex http client.
    /// </summary>
    public class CexHttpClient : ICexHttpClient
    {
        private StringBuilder _exceptionBuiler;

        public CexHttpClient()
        {
            _exceptionBuiler.Append("Something went wrong. ");
            _exceptionBuiler.Append("If you think this exception is not caused by you ");
            _exceptionBuiler.Append("open a new issue on https://github.com/Ryukote/CexCore ");
            _exceptionBuiler.Append("with given exception message and stack trace, and describe ");
            _exceptionBuiler.Append("step by step how to get to the exception.");
        }

        /// <summary>
        /// Calling GET endpoints on cex.io
        /// </summary>
        /// <returns>Tuple that represents HttpStatusCode and response content from called endpoint.</returns>
        /// <param name="url">Absolute url of the endpoint.</param>
        public async Task<Tuple<HttpStatusCode, string>> CexGetAsync(string url)
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
            catch(HttpRequestException ex)
            {
                throw new HttpRequestException(_exceptionBuiler.ToString(), ex);
            }
        }

        /// <summary>
        /// Calling POST endpoints on cex.io
        /// </summary>
        /// <returns>Tuple that represents HttpStatusCode and response content from called endpoint.</returns>
        /// <param name="url">Absolute url of the endpoint.</param>
        /// <param name="httpContent">Valid HTTP content.</param>
        public async Task<Tuple<HttpStatusCode, string>> CexPostAsync(string url, HttpContent httpContent)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpContent content = new StringContent(await httpContent.ReadAsStringAsync()))
                    {
                        content.Headers.ContentType.MediaType = "application/json";

                        var response = await client.PostAsync(url, httpContent);

                        var responseContent = await response.Content.ReadAsStringAsync();

                        return new Tuple<HttpStatusCode, string>(response.StatusCode, responseContent);
                    }
                }
            }
            catch(HttpRequestException ex)
            {
                throw new HttpRequestException(_exceptionBuiler.ToString(), ex);
            }
        }
    }
}
