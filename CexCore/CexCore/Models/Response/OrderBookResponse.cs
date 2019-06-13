using CexCore.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CexCore.Models.Response
{
    public class OrderBookResponse : IResponse
    {
        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty("bids")]
        public ICollection<ICollection<double>> OrderBookBids { get; set; }

        [JsonProperty("asks")]
        public ICollection<ICollection<double>> OrderBookAsks { get; set; }

        [JsonProperty("pair")]
        public string Pair { get; set; }

        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("sell_total")]
        public string SellTotalS { get; set; }

        [JsonProperty("buy_total")]
        public string BuyTotal { get; set; }
    }
}
