using CexCore.Contracts;
using Newtonsoft.Json;

namespace CexCore.Models.Response
{
    public class TickersForPairsResponse : IResponse
    {
        [JsonProperty("ok")]
        public string Ok { get; set; }

        [JsonProperty("tickers")]
        public string Command { get; set; }

        [JsonProperty("data")]
        public TickerResponse[] Data { get; set; }
    }
}
