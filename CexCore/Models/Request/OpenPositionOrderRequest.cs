using Newtonsoft.Json;
using System.Security.Cryptography;

namespace CexCore.Models.Request
{
    public class OpenPositionOrderRequest : EmptyPrivateRequest
    {
        public OpenPositionOrderRequest(HMAC hmac) : base(hmac)
        {
        }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("amount")]
        public ulong Amount { get; set; }

        [JsonProperty("msymbol")]
        public string MSymbol { get; set; }

        [JsonProperty("leverage")]
        public int Leverage { get; set; }

        [JsonProperty("ptype")]
        public string PType { get; set; }

        [JsonProperty("anySlippage")]
        public string AnySlippage { get; set; }

        [JsonProperty("eoprice")]
        public decimal EoPrice { get; set; }

        [JsonProperty("stopLossPrice")]
        public string StopLossPrice { get; set; }
    }
}
