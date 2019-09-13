using System.Security.Cryptography;
using Newtonsoft.Json;

namespace CexCore.Models.Request
{
    public class IDRequest : EmptyPrivateRequest
    {
        public IDRequest(HMAC hmac) : base(hmac)
        {
        }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
