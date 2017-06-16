using CEXIO.Api.Helpers;
using Newtonsoft.Json;

namespace CEXIO.Api.MarketEntities
{
    public class Ticker
    {
        [JsonProperty("timestamp")]
        public Timestamp Timestamp { get; internal set; }

        [JsonProperty("ask")]
        public decimal Ask { get; internal set; }

        [JsonProperty("bid")]
        public decimal Bid { get; internal set; }

        [JsonProperty("high")]
        public decimal High { get; internal set; }

        [JsonProperty("low")]
        public decimal Low { get; internal set; }

        [JsonProperty("last")]
        public decimal Last { get; internal set; }


        [JsonProperty("volume")]
        public decimal Volume24H { get; internal set; }

        [JsonProperty("volume30d")]
        public decimal Volume30d { get; internal set; }

        // TODO: Symbol Pair must be add.

    }
}
