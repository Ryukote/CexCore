using CexCore.Models.Common;
using Newtonsoft.Json;

namespace CexCore.Models.Response
{
    public class FeeData
    {
        [JsonProperty("BTC:USD")]
        public BaseFeeData BTC_USD { get; set; }

        [JsonProperty("ETH:USD")]
        public BaseFeeData ETH_USD { get; set; }

        [JsonProperty("BCH:USD")]
        public BaseFeeData BCH_USD { get; set; }

        [JsonProperty("BTG:USD")]
        public BaseFeeData BTG_USD { get; set; }

        [JsonProperty("DASH:USD")]
        public BaseFeeData DASH_USD { get; set; }

        [JsonProperty("LTC:USD")]
        public BaseFeeData LTC_USD { get; set; }

        [JsonProperty("XRP:USD")]
        public BaseFeeData XRP_USD { get; set; }

        [JsonProperty("XLM:USD")]
        public BaseFeeData XLM_USD { get; set; }

        [JsonProperty("ZEC:USD")]
        public BaseFeeData ZEC_USD { get; set; }

        [JsonProperty("OMG:USD")]
        public BaseFeeData OMG_USD { get; set; }

        [JsonProperty("MHC:USD")]
        public BaseFeeData MHC_USD { get; set; }

        [JsonProperty("GUSD:USD")]
        public BaseFeeData GUSD_USD { get; set; }

        [JsonProperty("BTC:EUR")]
        public BaseFeeData BTC_EUR { get; set; }

        [JsonProperty("ETH:EUR")]
        public BaseFeeData ETH_EUR { get; set; }

        [JsonProperty("BCH:EUR")]
        public BaseFeeData BCH_EUR { get; set; }

        [JsonProperty("BTG:EUR")]
        public BaseFeeData BTG_EUR { get; set; }

        [JsonProperty("DASH:EUR")]
        public BaseFeeData DASH_EUR { get; set; }

        [JsonProperty("XRP:EUR")]
        public BaseFeeData XRP_EUR { get; set; }

        [JsonProperty("XLM:EUR")]
        public BaseFeeData XLM_EUR { get; set; }

        [JsonProperty("ZEC:EUR")]
        public BaseFeeData ZEC_EUR { get; set; }

        [JsonProperty("OMG:EUR")]
        public BaseFeeData OMG_EUR { get; set; }

        [JsonProperty("MHC:EUR")]
        public BaseFeeData MHC_EUR { get; set; }

        [JsonProperty("GUSD:EUR")]
        public BaseFeeData GUSD_EUR { get; set; }

        [JsonProperty("BTC:GBP")]
        public BaseFeeData BTC_GBP { get; set; }

        [JsonProperty("ETH:GBP")]
        public BaseFeeData ETH_GBP { get; set; }

        [JsonProperty("BCH:GBP")]
        public BaseFeeData BCH_GBP { get; set; }

        [JsonProperty("DASH:GBP")]
        public BaseFeeData DASH_GBP { get; set; }

        [JsonProperty("ZEC:GBP")]
        public BaseFeeData ZEC_GBP { get; set; }

        [JsonProperty("MHC:GBP")]
        public BaseFeeData MHC_GBP { get; set; }

        [JsonProperty("BTC:RUB")]
        public BaseFeeData BTC_RUB { get; set; }

        [JsonProperty("ETH:BTC")]
        public BaseFeeData ETH_BTC { get; set; }

        [JsonProperty("BCH:BTC")]
        public BaseFeeData BCH_BTC { get; set; }

        [JsonProperty("BTG:BTC")]
        public BaseFeeData BTG_BTC { get; set; }

        [JsonProperty("DASH:BTC")]
        public BaseFeeData DASH_BTC { get; set; }

        [JsonProperty("XRP:BTC")]
        public BaseFeeData XRP_BTC { get; set; }

        [JsonProperty("XLM:BTC")]
        public BaseFeeData XLM_BTC { get; set; }

        [JsonProperty("ZEC:BTC")]
        public BaseFeeData ZEC_BTC { get; set; }

        [JsonProperty("OMG:BTC")]
        public BaseFeeData OMG_BTC { get; set; }

        [JsonProperty("MHC:BTC")]
        public BaseFeeData MHC_BTC { get; set; }

        [JsonProperty("GUSD:BTC")]
        public BaseFeeData GUSD_BTC { get; set; }

        [JsonProperty("MHC:ETH")]
        public BaseFeeData MHC_ETH { get; set; }
    }
}
