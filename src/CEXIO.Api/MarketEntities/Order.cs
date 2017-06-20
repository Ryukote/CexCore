using CEXIO.Api.Helpers;
using Newtonsoft.Json;

namespace CEXIO.Api.MarketEntities
{
    public class Order : EntityBase
    {
        private string _oType;

        [JsonProperty("id")]
        public long Id { get; private set; }

        [JsonProperty("time")]
        public Timestamp Time { get; private set; }

        public SymbolPairs Pair { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("pending")]
        public decimal Pending { get; private set; }

        [JsonProperty("type")]
        public string OType
        {
            get => _oType;
            private set
            {
                if (value == "buy")
                    Type = OrderType.Buy;

                else if (value == "sell")
                    Type = OrderType.Sell;

                _oType = value;
            }
        }

        public OrderType Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; private set; }

        public Order(SymbolPairs pair, decimal price, decimal amount, OrderType type)
        {
            Price = price;
            Amount = amount;
            Type = type;
            Pair = pair;
        }

        public Order()
        {

        }
    }
}
