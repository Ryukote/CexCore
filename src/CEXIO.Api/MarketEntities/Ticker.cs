using CEXIO.Api.Helpers;
using Newtonsoft.Json;

namespace CEXIO.Api.MarketEntities
{
    public class Ticker
    {
        [JsonProperty("timestamp")]
        public Timestamp Timestamp { get; internal set; }

        [JsonProperty("ask")]
        public decimal Ask { get; set; }

        [JsonProperty("bid")]
        public decimal Bid { get; set; }

        [JsonProperty("high")]
        public decimal High { get; set; }

        [JsonProperty("low")]
        public decimal Low { get; set; }

        [JsonProperty("last")]
        public decimal Last { get; set; }


        [JsonProperty("volume")]
        public decimal Volume24H { get; set; }

        [JsonProperty("volume30d")]
        public decimal Volume30d { get; set; }

        // TODO: Symbol Pair must be add.

    }
}
