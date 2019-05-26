using CexCore.Helpers;
using Newtonsoft.Json;

namespace CexCore.MarketEntities
{
    public class Balance : EntityBase
    {
        [JsonProperty("timestamp")]
        public Timestamp Timestamp { get; private set; }

        [JsonProperty("BTC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BTC { get; private set; }

        [JsonProperty("USD")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance USD { get; private set; }

        [JsonProperty("EUR")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance EUR { get; private set; }

        [JsonProperty("ETH")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ETH { get; private set; }

        [JsonProperty("RUB")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance RUB { get; private set; }

        [JsonProperty("GBP")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GBP { get; private set; }

        [JsonProperty("GHS")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GHS { get; private set; }

        [JsonProperty("XRP")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance XRP { get; private set; }

        [JsonProperty("XLM")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance XLM { get; private set; }

        [JsonProperty("DASH")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance DASH { get; private set; }
    }

    public class SymbolBalance : EntityBase
    {
        [JsonProperty("available")]
        public decimal Available { get; private set; }

        [JsonProperty("bonus")]
        public decimal Bonus { get; private set; }

        [JsonProperty("orders")]
        public decimal Orders { get; private set; }

        public SymbolBalance(decimal available, decimal bonus, decimal orders)
        {
            Available = available;
            Bonus = bonus;
            Orders = orders;
        }

    }
}
