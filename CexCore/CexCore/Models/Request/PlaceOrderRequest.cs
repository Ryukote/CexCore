using Newtonsoft.Json;

namespace CexCore.Models.Request
{
    public class PlaceOrderRequest : BaseRequest
    {
        public PlaceOrderRequest(string userId, string apiKey, string apiSecret) : base(userId, apiKey, apiSecret)
        {
        }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("order_type")]
        public string OrderType { get; set; }
    }
}
