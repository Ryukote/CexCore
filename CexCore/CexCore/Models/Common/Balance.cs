using Newtonsoft.Json;

namespace CexCore.Models.Common
{
    public class Balance
    {
        /// <summary>
        /// Available balance.
        /// </summary>
        [JsonProperty("available")]
        public string Available { get; set; }

        /// <summary>
        /// Balance in pending orders.
        /// </summary>
        [JsonProperty("orders")]
        public string Orders { get; set; }

        /// <summary>
        /// Refferal program bonus.
        /// </summary>
        [JsonProperty("bonus")]
        public string Bonus { get; set; }
    }
}
