using Newtonsoft.Json;

namespace CexCore.Models
{
    public class CancelOrdersForGivenPair
    {
        [JsonProperty("symbol1")]
        public string FirstCurrency { get; set; }
        [JsonProperty("symbol2")]
        public string SecondCurrency { get; set; }
    }
}
