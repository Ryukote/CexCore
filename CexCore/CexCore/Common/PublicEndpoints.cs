using static CexCore.Common.Symbols;

namespace CexCore.Common
{
    internal class PublicEndpoints
    {
        internal static string CurrencyLimits = "https://cex.io/api/currency_limits";

        internal static string Ticker(CryptoCurrency cryptoCurrency, Fiat fiat) =>
            $"https://cex.io/api/ticker/{cryptoCurrency.ToString()}/{fiat.ToString()}";

        internal static string TickersForAllPairsByMarkets = "https://cex.io/api/tickers";
    }
}
