namespace CexCore.Common
{
    /// <summary>
    /// Enumerations for crypto currencies and fiat.
    /// </summary>
    public class Symbols
    {
        /// <summary>
        /// Crypto currency symbols.
        /// </summary>
        public enum CryptoCurrency
        {
            BTC,
            ETH,
            BCH,
            BTG,
            DASH,
            LTC,
            XRP,
            XLM,
            ZEC,
            OMG,
            MHC,
            GUSD,
            TRX,
            BTT
        }

        /// <summary>
        /// Fiat symbols.
        /// </summary>
        public enum Fiat
        {
            USD,
            EUR,
            GBP,
            RUB
        }
    }
}
