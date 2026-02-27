using System;
using System.Net;
using System.Net.Http;

namespace CexCore.Exceptions
{
    public class ApiException : Exception
    {
        private const string DefaultHelpLink = "https://cex.io/api";

        public HttpMethod RequestMethod { get; private set; }
        public Uri RequestUri { get; private set; }
        public HttpStatusCode ResponseStatusCode { get; private set; }
        public string ResponseReasonPhrase { get; private set; }
        public string ApiError { get; private set; }

        public ApiException(HttpResponseMessage response, string message, string apiError = null) :
            base(FormatMessage(message, apiError))
        {
            var request = response.RequestMessage;

            RequestMethod = request.Method;
            RequestUri = request.RequestUri;

            ResponseStatusCode = response.StatusCode;
            ResponseReasonPhrase = response.ReasonPhrase;
            ApiError = apiError;
            HelpLink = DefaultHelpLink;
        }

        protected static string FormatMessage(string message, string apiError)
        {
            if (string.IsNullOrWhiteSpace(apiError))
                return message;

            return $"{message} CEX.IO details: {apiError}";
        }
    }
}
