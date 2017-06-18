using System.Net.Http;

namespace CEXIO.Api.Exceptions
{
    public class InvalidApiKeyException : ApiException
    {
        public InvalidApiKeyException(HttpResponseMessage response, string message) : 
            base(response, message)
        {

        }
    }
}
