using Newtonsoft.Json;

namespace CexCore.Models.Request
{
    public class CancelOrderRequest : BaseRequest
    {
        public CancelOrderRequest(string userId, string apiKey, string apiSecret) : base(userId, apiKey, apiSecret)
        {
        }

        [JsonProperty("id")]
        public ulong Id { get; set; }
    }
}
