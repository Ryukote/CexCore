using Newtonsoft.Json;

namespace CexCore.Models.Common
{
    public class ClosePositionData
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
        public Pair Pair { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("profit")]
        public string Profit { get; set; }
    }
}
