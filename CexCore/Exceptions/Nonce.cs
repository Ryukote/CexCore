using System.Net.Http;

namespace CexCore.Exceptions
{
    public class NonceException : ApiException
    {
        private const string DefaultMessage = "Nonce validation failed. Ensure each authenticated request uses a strictly increasing nonce.";

        public NonceException(HttpResponseMessage response) :
            base(response, DefaultMessage)
        {
        }

        public NonceException(HttpResponseMessage response, string message) :
            base(response, message)
        {
        }

        public NonceException(HttpResponseMessage response, string message, string apiError) :
            base(response, message, apiError)
        {
        }
    }
}
