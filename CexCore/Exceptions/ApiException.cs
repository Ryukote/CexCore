using System;
using System.Net;
using System.Net.Http;

namespace CexCore.Exceptions
{
    public class ApiException : Exception
    {
        public HttpMethod RequestMethod { get; private set; }
        public Uri RequestUri { get; private set; }
        public HttpStatusCode ResponseStatusCode { get; private set; }
        public string ResponseReasonPhrase { get; private set; }

        public ApiException(HttpResponseMessage response, string message) : base(message)
        {
            var request = response.RequestMessage;

            RequestMethod = request.Method;
            RequestUri = request.RequestUri;

            ResponseStatusCode = response.StatusCode;
            ResponseReasonPhrase = response.ReasonPhrase;
        }
    }
}
