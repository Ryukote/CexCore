using CexCore.Contracts;
using Newtonsoft.Json;

namespace CexCore.Models.Response
{
    public class GetMyFeeResponse : IResponse
    {
        [JsonProperty("ok")]
        public string Ok { get; set; }

        [JsonProperty("e")]
        public string Command { get; set; }

        [JsonProperty("data")]
        public FeeData FeeData { get; set; }
    }
}
