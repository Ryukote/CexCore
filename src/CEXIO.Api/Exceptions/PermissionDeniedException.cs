using System.Net.Http;

namespace CEXIO.Api.Exceptions
{
    public class PermissionDeniedException : ApiException
    {
        public PermissionDeniedException(HttpResponseMessage response, string message) : 
            base(response, message)
        {
        }
    }
}
