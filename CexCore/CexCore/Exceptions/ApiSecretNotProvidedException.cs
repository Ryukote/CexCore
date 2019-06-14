using System;

namespace CexCore.Exceptions
{
    public class ApiSecretNotProvidedException : Exception
    {
        public ApiSecretNotProvidedException()
        {
        }

        public ApiSecretNotProvidedException(string message)
            : base(message)
        {
        }

        public ApiSecretNotProvidedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
