using System.Net.Http;

namespace CexCore.Exceptions
{
    public class InvalidApiKeyException : ApiException
    {
        public InvalidApiKeyException(HttpResponseMessage response, string message) :
            base(response, message)
        {

        }
    }
}
