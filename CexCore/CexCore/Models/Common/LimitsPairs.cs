using Newtonsoft.Json;

namespace CexCore.Models.Common
{
    public class LimitsPairs
    {
        [JsonProperty("symbol1")]
        public string Symbol1 { get; set; }

        [JsonProperty("symbol2")]
        public string Symbol2 { get; set; }

        [JsonProperty("minLotSize")]
        public decimal MinLotSize { get; set; }

        [JsonProperty("minLotSize2")]
        public decimal MinLotSize2 { get; set; }

        [JsonProperty("minPrice")]
        public string MinPrice { get; set; }

        [JsonProperty("maxPrice")]
        public string MaxPrice { get; set; }
    }
}
