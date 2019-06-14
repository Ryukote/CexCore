using Newtonsoft.Json;

namespace CexCore.Models.Request
{
    public class OpenPositionOrderRequest : BaseRequest
    {
        public OpenPositionOrderRequest(string userId, string apiKey, string apiSecret) : base(userId, apiKey, apiSecret)
        {
        }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("msymbol")]
        public string MSymbol { get; set; }

        [JsonProperty("leverage")]
        public decimal Leverage { get; set; }

        [JsonProperty("ptype")]
        public string PType { get; set; }

        [JsonProperty("anySlippage")]
        public string AnySlippage { get; set; }

        [JsonProperty("eoprice")]
        public decimal EOPrice { get; set; }

        [JsonProperty("stopLossPrice")]
        public string StopLossPrice { get; set; }
    }
}
