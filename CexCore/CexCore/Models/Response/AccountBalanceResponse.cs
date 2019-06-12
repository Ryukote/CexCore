using CexCore.Models.Common;
using Newtonsoft.Json;

namespace CexCore.Models.Response
{
    public class AccountBalanceResponse
    {
        /// <summary>
        /// UNIX timestamp.
        /// </summary>
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// User ID.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// BTC balance.
        /// </summary>
        [JsonProperty("BTC")]
        public Balance BalanceBTC { get; set; }

        /// <summary>
        /// BCH balance.
        /// </summary>
        [JsonProperty("BCH")]
        public Balance BalanceBCH { get; set; }

        /// <summary>
        /// ETH balance.
        /// </summary>
        [JsonProperty("ETH")]
        public Balance BalanceETH { get; set; }

        /// <summary>
        /// LTC balance.
        /// </summary>
        [JsonProperty("LTC")]
        public Balance BalanceLTC { get; set; }

        /// <summary>
        /// DASH balance.
        /// </summary>
        [JsonProperty("DASH")]
        public Balance BalanceDASH { get; set; }

        /// <summary>
        /// ZEC balance.
        /// </summary>
        [JsonProperty("ZEC")]
        public Balance BalanceZEC { get; set; }

        /// <summary>
        /// BTG balance.
        /// </summary>
        [JsonProperty("BTG")]
        public Balance BalanceBTG { get; set; }

        /// <summary>
        /// XRP balance.
        /// </summary>
        [JsonProperty("XRP")]
        public Balance BalanceXRP { get; set; }

        /// <summary>
        /// XLM balance.
        /// </summary>
        [JsonProperty("XLM")]
        public Balance BalanceXLM { get; set; }

        /// <summary>
        /// OMG balance.
        /// </summary>
        [JsonProperty("OMG")]
        public Balance BalanceOMG { get; set; }

        /// <summary>
        /// MHC balance.
        /// </summary>
        [JsonProperty("MHC")]
        public Balance BalanceMHC { get; set; }

        /// <summary>
        /// GUSD balance.
        /// </summary>
        [JsonProperty("GUSD")]
        public Balance BalanceGUSD { get; set; }

        /// <summary>
        /// USD balance.
        /// </summary>
        [JsonProperty("USD")]
        public Balance BalanceUSD { get; set; }

        /// <summary>
        /// EUR balance.
        /// </summary>
        [JsonProperty("EUR")]
        public Balance BalanceEUR { get; set; }

        /// <summary>
        /// GBP balance.
        /// </summary>
        [JsonProperty("GBP")]
        public Balance BalanceGBP { get; set; }

        /// <summary>
        /// RUB balance.
        /// </summary>
        [JsonProperty("RUB")]
        public Balance BalanceRUB { get; set; }
    }
}
