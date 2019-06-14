using CexCore.Contracts;
using Newtonsoft.Json;

namespace CexCore.Models.Response
{
    public class CurrencyLimitsResponse : IResponse
    {
        [JsonProperty("e")]
        public string Command { get; set; }

        [JsonProperty("ok")]
        public string Ok { get; set; }

        [JsonProperty("data")]
        public Common.Data Data { get; set; }
    }
}
