using Newtonsoft.Json;

namespace CexCore.Models.Response
{
    public class OrderBookAsks
    {
        [JsonProperty]
        public decimal[] Asks { get; set; }
    }
}
