using CexCore.Helpers;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CexCore.Common
{
    public sealed class ApiCredentials
    {
        private readonly HMAC _hmac;

        public string UserId { get; private set; }
        public string ApiKey { get; private set; }

        /// <summary>
        /// You need credentials to access private API 's.
        /// To see where can you find API informations
        /// <seealso cref="https://cex.io/trade/profile#/api"/>
        /// </summary>
        /// <param name="userId">CEX.IO user id</param>
        /// <param name="apiKey">Api key</param>
        /// <param name="apiSecret">Api secret</param>
        public ApiCredentials(string userId, string apiKey, string apiSecret)
        {
            UserId = userId;
            ApiKey = apiKey;

            _hmac = new HMACSHA256(Encoding.UTF8.GetBytes(apiSecret));

        }

        public string GenerateSignature(out long nonce)
        {
            nonce = Nonce.Next();

            var bytes = Encoding.UTF8.GetBytes($"{nonce}{UserId}{ApiKey}");
            var hash = _hmac.ComputeHash(bytes);

            return string.Concat(hash.Select(b => b.ToString("X2")));
        }

    }
}
