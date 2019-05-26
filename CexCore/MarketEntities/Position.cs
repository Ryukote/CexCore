using Newtonsoft.Json;

namespace CexCore.MarketEntities
{
    public class Position : EntityBase
    {
        public SymbolPairs Pair { get; set; }

        [JsonProperty("symbol")]
        public Symbols Symbol { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("leverage")]
        public int Leverage { get; set; }

        [JsonProperty("ptype")]
        public PositionType Type { get; set; }

        public bool AnySlippage { get; set; } = true;

        [JsonProperty("oprice")]
        public decimal EstimatedOpenPrice { get; set; }

        [JsonProperty("stopLossPrice")]
        public decimal StopLossPrice { get; set; }

        public Position()
        {

        }
    }
}
