using CexCore.Contracts;
using Newtonsoft.Json;

namespace CexCore.Models.Response
{
    public class TickerResponse : IResponse
    {
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("low")]
        public string Low { get; set; }

        [JsonProperty("high")]
        public string High { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }

        [JsonProperty("volume30d")]
        public string Volume30D { get; set; }

        [JsonProperty("bid")]
        public string Bid { get; set; }

        [JsonProperty("ask")]
        public string Ask { get; set; }
    }
}
