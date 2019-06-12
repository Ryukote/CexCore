using CexCore.Contracts;
using Newtonsoft.Json;

namespace CexCore.Models.Response
{
    public class LastPriceResponse : IResponse
    {
        [JsonProperty("lprice")]
        public string LastPrice { get; set; }

        [JsonProperty("curr1")]
        public string Currency1 { get; set; }

        [JsonProperty("curr2")]
        public string Currency2 { get; set; }
    }
}
