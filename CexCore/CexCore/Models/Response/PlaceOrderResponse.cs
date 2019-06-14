using CexCore.Contracts;
using Newtonsoft.Json;

namespace CexCore.Models.Response
{
    public class PlaceOrderResponse : IResponse
    {
        [JsonProperty("complete")]
        public bool Complete { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("time")]
        public ulong Time { get; set; }

        [JsonProperty("pending")]
        public string Pending { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
