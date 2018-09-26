using System.Net.Http;

namespace CexCore.Exceptions
{
    public class ApiKeyIsMissingException : ApiException
    {
        public ApiKeyIsMissingException(HttpResponseMessage response, string message) :
            base(response, message)
        {
        }
    }
}
