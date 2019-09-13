using Newtonsoft.Json;

namespace CexCore.Models.Response
{
    public class ClosePositionDataResponse
    {
        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("ctime")]
        public ulong CTime { get; set; }

        [JsonProperty("ptype")]
        public string PType { get; set; }

        [JsonProperty("msymbol")]
        public string MSymbol { get; set; }

        [JsonProperty("pair")]
        public ClosePositionPairResponse ClosePositionPair { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("profit")]
        public decimal Profit { get; set; }
    }
}
