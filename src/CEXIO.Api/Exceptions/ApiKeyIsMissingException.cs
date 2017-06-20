using System.Net.Http;

namespace CEXIO.Api.Exceptions
{
    public class ApiKeyIsMissingException : ApiException
    {
        public ApiKeyIsMissingException(HttpResponseMessage response, string message) : 
            base(response, message)
        {
        }
    }
}
