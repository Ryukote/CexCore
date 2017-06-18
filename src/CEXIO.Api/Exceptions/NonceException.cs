using System.Net.Http;

namespace CEXIO.Api.Exceptions
{
    public class NonceException : ApiException
    {
        public NonceException(HttpResponseMessage response, string message) : 
            base(response, message)
        {
        }
    }
}
