using Newtonsoft.Json;

namespace CexCore.Models.Response
{
    public class OrderBookBids
    {
        [JsonProperty]
        public decimal[] Bids { get; set; }
    }
}
