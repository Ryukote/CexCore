using System.Net.Http;

namespace CexCore.Exceptions
{
    public class InvalidApiKeyException : ApiException
    {
        private const string DefaultMessage = "Provided API key is invalid. Check key value and API key permissions on CEX.IO.";

        public InvalidApiKeyException(HttpResponseMessage response) :
            base(response, DefaultMessage)
        {
        }

        public InvalidApiKeyException(HttpResponseMessage response, string message) :
            base(response, message)
        {
        }

        public InvalidApiKeyException(HttpResponseMessage response, string message, string apiError) :
            base(response, message, apiError)
        {
        }
    }
}
