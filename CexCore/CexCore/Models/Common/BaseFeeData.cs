using Newtonsoft.Json;

namespace CexCore.Models.Common
{
    public class BaseFeeData
    {
        [JsonProperty("sell")]
        public string Sell { get; set; }

        [JsonProperty("buyMaker")]
        public string BuyMaker { get; set; }

        [JsonProperty("buy")]
        public string Buy { get; set; }

        [JsonProperty("sellMaker")]
        public string SellMaker { get; set; }
    }
}
