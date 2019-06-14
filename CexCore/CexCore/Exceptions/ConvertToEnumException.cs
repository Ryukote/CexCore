using System;

namespace CexCore.Exceptions
{
    public class ConvertToEnumException : Exception
    {
        public ConvertToEnumException()
        {
        }

        public ConvertToEnumException(string message)
            : base(message)
        {
        }

        public ConvertToEnumException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
