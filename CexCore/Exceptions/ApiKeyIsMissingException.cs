using System.Net.Http;

namespace CexCore.Exceptions
{
    public class ApiKeyIsMissingException : ApiException
    {
        private const string DefaultMessage = "API key is missing in request. Provide credentials before calling private CEX.IO endpoints.";

        public ApiKeyIsMissingException(HttpResponseMessage response) :
            base(response, DefaultMessage)
        {
        }

        public ApiKeyIsMissingException(HttpResponseMessage response, string message) :
            base(response, message)
        {
        }

        public ApiKeyIsMissingException(HttpResponseMessage response, string message, string apiError) :
            base(response, message, apiError)
        {
        }
    }
}
