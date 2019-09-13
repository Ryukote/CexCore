using Newtonsoft.Json;

namespace CexCore.Models.Request
{
    public class PositionRequest : EmptyPrivateRequest
    {
        public PositionRequest(string apiSecret) : base(apiSecret)
        {
        }

        [JsonProperty("id")]
        public ulong PositionId { get; set; }
    }
}
