using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CexCore.Utilities
{
    internal static class SignatureGenerator
    {
        internal static string Compute(string userId, string apiKey, long nonce, string apiSecret)
        {
            byte[] secretBytes = Encoding.UTF8.GetBytes(apiSecret);
            HMAC hmac = new HMACSHA256(secretBytes);

            var bytes = Encoding.UTF8.GetBytes($"{nonce}{userId}{apiKey}");
            var hash = hmac.ComputeHash(bytes);

            return string.Concat(hash.Select(b => b.ToString("X2")));
        }
    }
}
