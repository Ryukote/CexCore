using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CexCore.Models.Response
{
    public class Data
    {
        [JsonProperty("pairs")]
        public LimitsPairs[] Pairs { get; set; }
    }
}
