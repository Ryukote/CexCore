using Newtonsoft.Json;

namespace CexCore.Models.Request
{
    public class IDRequest : EmptyPrivateRequest
    {
        public IDRequest(string apiSecret) : base(apiSecret)
        {
        }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
