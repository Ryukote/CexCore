using CexCore.Contracts;
using CexCore.Models.Common;
using Newtonsoft.Json;

namespace CexCore.Models.Response
{
    public class ClosePositionResponse : IResponse
    {
        [JsonProperty("ok")]
        public string Ok { get; set; }

        [JsonProperty("tickers")]
        public string Command { get; set; }

        [JsonProperty("data")]
        public ClosePositionData ClosePositionData { get; set; }
    }
}
