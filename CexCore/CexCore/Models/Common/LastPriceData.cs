using Newtonsoft.Json;

namespace CexCore.Models.Common
{
    public class LastPriceData
    {
        [JsonProperty("symbol1")]
        public string Symbol1 { get; set; }

        [JsonProperty("symbol2")]
        public string Symbol2 { get; set; }

        [JsonProperty("lprice")]
        public string LastPrice { get; set; }
    }
}
