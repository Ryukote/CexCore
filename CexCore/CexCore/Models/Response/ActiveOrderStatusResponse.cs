using CexCore.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CexCore.Models.Response
{
    public class ActiveOrderStatusResponse : IResponse
    {
        [JsonProperty("e")]
        public string Command { get; set; }

        [JsonProperty("ok")]
        public string Ok { get; set; }

        [JsonProperty("data")]
        public ICollection<ICollection<string>> Data { get; set; }
    }
}
