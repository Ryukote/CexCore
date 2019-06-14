using CexCore.Contracts;
using Newtonsoft.Json;

namespace CexCore.Models.Common
{
    public class TradeHistory : IResponse
    {
        [JsonProperty("tid")]
        public string TradeId { get; set; }

        [JsonProperty("type")]
        public string OrderType { get; set; }

        [JsonProperty("amount")]
        public string TradeAmount { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("date")]
        public string Timestamp { get; set; }
    }
}
