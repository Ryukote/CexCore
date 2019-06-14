using Newtonsoft.Json;

namespace CexCore.Models.Common
{
    public class OpenPositionOrderData
    {
        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("otime")]
        public ulong OTime { get; set; }

        [JsonProperty("psymbol")]
        public string PSymbol { get; set; }

        [JsonProperty("msymbol")]
        public string MSymbol { get; set; }

        [JsonProperty("lsymbol")]
        public string LSymbol { get; set; }

        [JsonProperty("pair")]
        public OpenPositionOrderPair OpenPositionOrderPair { get; set; }

        [JsonProperty("pamount")]
        public string PAmount { get; set; }

        [JsonProperty("omamount")]
        public string OMAmount { get; set; }

        [JsonProperty("lamount")]
        public string LAmount { get; set; }

        [JsonProperty("oprice")]
        public string OPrice { get; set; }

        [JsonProperty("ptype")]
        public string PType { get; set; }

        [JsonProperty("stopLossPrice")]
        public string StopLossPrice { get; set; }

        [JsonProperty("pfee")]
        public string PFee { get; set; }

        [JsonProperty("cfee")]
        public string CFee { get; set; }

        [JsonProperty("tfeeamount")]
        public string TFeeAmount { get; set; }
    }
}
