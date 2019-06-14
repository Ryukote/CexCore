using Newtonsoft.Json;

namespace CexCore.Models.Common
{
    public class Data
    {
        [JsonProperty("pairs")]
        public LimitsPairs[] Pairs { get; set; }
    }
}
