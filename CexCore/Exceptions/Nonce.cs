using System.Net.Http;

namespace CexCore.Exceptions
{
    public class NonceException : ApiException
    {
        public NonceException(HttpResponseMessage response, string message) :
            base(response, message)
        {
        }
    }
}
