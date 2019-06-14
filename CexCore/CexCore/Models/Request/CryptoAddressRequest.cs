using Newtonsoft.Json;

namespace CexCore.Models.Request
{
    public class CryptoAddressRequest : BaseRequest
    {
        public CryptoAddressRequest(string userId, string apiKey, string apiSecret) : base(userId, apiKey, apiSecret)
        {
        }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
