using Newtonsoft.Json;

namespace CexCore.Models.Common
{
    public class OrderBookBids
    {
        [JsonProperty]
        public decimal[] Bids { get; set; }
    }
}
