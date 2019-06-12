using System;

namespace CexCore.Exceptions
{
    public class UserIdNotProvidedException : Exception
    {
        public UserIdNotProvidedException()
        {
        }

        public UserIdNotProvidedException(string message)
            : base(message)
        {
        }

        public UserIdNotProvidedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
