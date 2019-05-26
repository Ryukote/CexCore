using System;
using System.Globalization;
using System.Threading;

namespace CexCore.Helpers
{
    public static class Nonce
    {
        private const int IncrementValue = 1;

        private static long _nonce;
        private static readonly object LockObj = new object();

        static Nonce()
        {
            lock (LockObj)
            {
                var nonceString = DateTime.UtcNow.Subtract(Timestamp.EpochStart)
                    .TotalSeconds
                    .ToString(CultureInfo.InvariantCulture)
                    .Split('.')[0];

                _nonce = Convert.ToInt32(nonceString);
            }
        }

        public static long Next()
        {
            return Interlocked.Add(ref _nonce, IncrementValue);
        }
    }
}
