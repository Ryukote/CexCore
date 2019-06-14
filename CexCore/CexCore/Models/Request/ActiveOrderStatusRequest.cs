using Newtonsoft.Json;

namespace CexCore.Models.Request
{
    public class ActiveOrderStatusRequest : BaseRequest
    {
        public ActiveOrderStatusRequest(string userId, string apiKey, string apiSecret) : base(userId, apiKey, apiSecret)
        {
        }

        [JsonProperty("orders_list")]
        public string[] OrdersList { get; set; }
    }
}
