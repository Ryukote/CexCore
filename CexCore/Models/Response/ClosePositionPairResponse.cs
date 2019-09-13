using Newtonsoft.Json;

namespace CexCore.Models.Response
{
    public class ClosePositionPairResponse
    {
        [JsonProperty("symbol1")]
        public string Symbol1 { get; set; }

        [JsonProperty("symbol2")]
        public string Symbol2 { get; set; }
    }
}
