using System.Text;

namespace CexCore.Data
{
    public static class CexConstants
    {
        #region Endpoint constants

        #region Account endpoints
        public static string CancelOrderUrl = "https://cex.io/api/cancel_order/";

        public static string CacelAllOrderWithPairsUrl(string symbol1, string symbol2) => $"https://cex.io/api/cancel_orders/{symbol1}/{symbol2}";

        public static string ClosePositionUrl(string symbol1, string symbol2) => $"https://cex.io/api/close_position/{symbol1}/{symbol2}";

        public static string CryptoAddressUrl = "https://cex.io/api/get_address/";

        public static string BalanceUrl = "https://cex.io/api/balance/";

        public static string OpenOrdersUrl = "https://cex.io/api/open_orders/";

        public static string OpenOrdersByPairUrl(string symbol1, string symbol2) => $"https://cex.io/api/open_orders/{symbol1}/{symbol2}";

        public static string OpenPositionUrl(string symbol1, string symbol2) => $"https://cex.io/api/open_position/{symbol1}/{symbol2}";
        #endregion

        #endregion

        #region Exception messages
        public static string GeneralException = "Something went wrong." + 
            " If you think this exception is not caused by you, open" + 
            " a new issue on https://github.com/Ryukote/CexCore" + 
            " with given exception message and stack trace and describe" +
            " step by step how to get to the exception.";

        public static string HttpPostRequestException = "Something is wrong with a POST request." +
            " Check if CEX.IO API is live on: https://status.cex.io" +
            " or check if your url and body is valid.";

        public static string InvalidJsonException = "Your JSON is not valid.";
        #endregion
    }
}
