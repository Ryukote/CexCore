using CexCore.Contracts;
using Newtonsoft.Json;

namespace CexCore.Models.Response
{
    public class CancelOrderResponse : IResponse
    {
        [JsonProperty]
        public bool IsCanceled { get; set; }
    }
}
