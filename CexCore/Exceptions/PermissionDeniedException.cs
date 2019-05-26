using System.Net.Http;

namespace CexCore.Exceptions
{
    public class PermissionDeniedException : ApiException
    {
        public PermissionDeniedException(HttpResponseMessage response, string message) :
            base(response, message)
        {
        }
    }
}
