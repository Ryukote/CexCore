using Newtonsoft.Json;

namespace CexCore.Models.Request
{
    public class AddressRequest : EmptyPrivateRequest
    {
        public AddressRequest(string apiSecret) : base(apiSecret)
        {
        }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
