using static CexCore.Common.Symbols;

namespace CexCore.Common
{
    internal class PublicEndpoints
    {
        internal static string CurrencyLimits = "https://cex.io/api/currency_limits";

        internal static string Ticker(CryptoCurrency cryptoCurrency, Fiat fiat) =>
            $"https://cex.io/api/ticker/{cryptoCurrency.ToString()}/{fiat.ToString()}";

        internal static string TickersForAllPairsByMarkets = "https://cex.io/api/tickers";

        internal static string LastPrice(string symbol1, string symbol2) =>
            $"https://cex.io/api/last_price/{symbol1}/{symbol2}";

        internal static string LastPricesForGivenMarkets = "https://cex.io/api/last_prices";

        internal static string Converter(string symbol1, string symbol2) => $"https://cex.io/api/convert/{symbol1}/{symbol2}";

        internal static string OrderBook = "https://cex.io/api/order_book";

        internal static string TradeHistory(string symbol1, string symbol2, string since) =>
            $"https://cex.io/api/trade_history/{symbol1}/{symbol2}/{since}";
    }
}
