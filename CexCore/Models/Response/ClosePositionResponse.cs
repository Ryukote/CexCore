using Newtonsoft.Json;
using System.Net;

namespace CexCore.Models.Response
{
    public class ClosePositionResponse
    {
        [JsonProperty("e")]
        public string Command { get; set; }

        [JsonProperty("ok")]
        public string Ok { get; set; }

        [JsonProperty("data")]
        public ClosePositionDataResponse Data { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
