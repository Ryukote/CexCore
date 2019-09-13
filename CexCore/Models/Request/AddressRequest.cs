using Newtonsoft.Json;
using System.Security.Cryptography;

namespace CexCore.Models.Request
{
    public class AddressRequest : EmptyPrivateRequest
    {
        public AddressRequest(HMAC hmac) : base(hmac)
        {
        }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
