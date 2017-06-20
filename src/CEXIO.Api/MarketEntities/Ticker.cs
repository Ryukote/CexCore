using CEXIO.Api.Helpers;
using Newtonsoft.Json;

namespace CEXIO.Api.MarketEntities
{
    public class Ticker : EntityBase
    {
        [JsonProperty("timestamp")]
        public Timestamp Timestamp { get; private set; }

        [JsonProperty("ask")]
        public decimal Ask { get; private set; }

        [JsonProperty("bid")]
        public decimal Bid { get; private set; }

        [JsonProperty("high")]
        public decimal High { get; private set; }

        [JsonProperty("low")]
        public decimal Low { get; private set; }

        [JsonProperty("last")]
        public decimal Last { get; private set; }

        [JsonProperty("volume")]
        public decimal Volume24H { get; private set; }

        [JsonProperty("volume30d")]
        public decimal Volume30d { get; private set; }

    }
}
