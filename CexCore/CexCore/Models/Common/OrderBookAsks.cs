using Newtonsoft.Json;

namespace CexCore.Models.Common
{
    public class OrderBookAsks
    {
        [JsonProperty]
        public decimal[] Asks { get; set; }
    }
}
