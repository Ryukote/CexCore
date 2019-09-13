using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CexCore.Models.Request
{
    public class EmptyPrivateRequest
    {
        private static string _apiSecret;

        public EmptyPrivateRequest(string apiSecret)
        {
            _apiSecret = apiSecret;
        }

        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("signature")]
        public string Signature { get; set; } = string.Concat(new HMACSHA256(Encoding.UTF8.GetBytes(_apiSecret)).Hash.Select(b => b.ToString("X2")));
        [JsonProperty("nonce")]
        public string Nonce { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
    }
}
