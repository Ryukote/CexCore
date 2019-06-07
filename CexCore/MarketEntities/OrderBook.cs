using CexCore.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CexCore.MarketEntities
{
    public class OrderBook : EntityBase
    {
        [JsonProperty("timestamp")]
        public Timestamp Timestamp { get; set; }

        [JsonProperty("bids")]
        public IEnumerable<IEnumerable<decimal>> Bids { get; set; }

        [JsonProperty("asks")]
        public IEnumerable<IEnumerable<decimal>> Asks { get; set; }

        [JsonProperty("pair")]
        public string Pair { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("sell_total")]
        public string SellTotal { get; set; }

        [JsonProperty("buy_total")]
        public string BuyTotal { get; set; }
    }
}
