using Newtonsoft.Json;

namespace CexCore.Models.Request
{
    public class CancelReplaceOrderRequest : BaseRequest
    {
        public CancelReplaceOrderRequest(string userId, string apiKey, string apiSecret) : base(userId, apiKey, apiSecret)
        {
        }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }
    }
}
