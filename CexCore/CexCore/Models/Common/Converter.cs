using CexCore.Contracts;
using Newtonsoft.Json;

namespace CexCore.Models.Common
{
    public class Converter : IResponse
    {
        [JsonProperty("amnt")]
        public string Amount { get; set; }
    }
}
