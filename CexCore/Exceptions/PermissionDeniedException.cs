using System.Net.Http;

namespace CexCore.Exceptions
{
    public class PermissionDeniedException : ApiException
    {
        private const string DefaultMessage = "Permission denied by CEX.IO. Check API key scope and account permissions.";

        public PermissionDeniedException(HttpResponseMessage response) :
            base(response, DefaultMessage)
        {
        }

        public PermissionDeniedException(HttpResponseMessage response, string message) :
            base(response, message)
        {
        }

        public PermissionDeniedException(HttpResponseMessage response, string message, string apiError) :
            base(response, message, apiError)
        {
        }
    }
}
