using CEXIO.Api.Helpers;
using Newtonsoft.Json;

namespace CEXIO.Api.MarketEntities
{
    public class Trade : EntityBase
    {
        [JsonProperty("date")]
        public Timestamp Date { get; internal set; }

        [JsonProperty("type")]
        public OrderType Type { get; internal set; }

        [JsonProperty("amount")]
        public decimal Amount { get; internal set; }

        [JsonProperty("price")]
        public decimal Price { get; internal set; }

        [JsonProperty("tid")]
        public TradeId Id { get; internal set; }

    }
}
