using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace CexCore.Models.Response
{
    public class CancelOrdersForGivenPairResponse
    {
        [JsonProperty("e")]
        public string Command { get; set; }

        [JsonProperty("ok")]
        public string Ok { get; set; }

        [JsonProperty("data")]
        public ICollection<string> Data { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
