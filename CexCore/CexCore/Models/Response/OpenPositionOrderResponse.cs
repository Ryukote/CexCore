using CexCore.Contracts;
using Newtonsoft.Json;

namespace CexCore.Models.Response
{
    public class OpenPositionOrderResponse : IResponse
    {
        [JsonProperty("e")]
        public string Command { get; set; }

        [JsonProperty("ok")]
        public string Ok { get; set; }

        [JsonProperty("data")]
        public Common.OpenPositionOrderData OpenPositionOrderData { get; set; }
    }
}
