using System;

namespace CexCore.Exceptions
{
    public class CexNullException : Exception
    {
        public CexNullException()
        {
        }

        public CexNullException(string message)
            : base(message)
        {
        }

        public CexNullException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
