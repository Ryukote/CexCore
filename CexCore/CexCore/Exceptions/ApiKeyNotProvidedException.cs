using System;

namespace CexCore.Exceptions
{
    public class ApiKeyNotProvidedException : Exception
    {
        public ApiKeyNotProvidedException()
        {
        }

        public ApiKeyNotProvidedException(string message)
            : base(message)
        {
        }

        public ApiKeyNotProvidedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
