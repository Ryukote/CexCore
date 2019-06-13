using System;

namespace CexCore.Exceptions
{
    public class CexCollectionException : Exception
    {
        public CexCollectionException()
        {
        }

        public CexCollectionException(string message)
            : base(message)
        {
        }

        public CexCollectionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
