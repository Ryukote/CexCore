namespace CexCore.Common
{
    /// <summary>
    /// Endpoints for account API
    /// </summary>
    internal static class AccountEndpoints
    {
        #region String values
        internal static string AccountBalance = "https://cex.io/api/balance/";

        internal static string OpenOrders = "https://cex.io/api/open_orders/";

        internal static string ActiveOrderStatus = "https://cex.io/api/active_orders_status";

        internal static string CancelOrder = "https://cex.io/api/cancel_order/";

        internal static string CryptoAddress = "https://cex.io/api/get_address/";

        internal static string GetMyFee = "https://cex.io/api/get_myfee/";
        #endregion

        #region String methods
        internal static string OpenOrdersByPair(string symbol1, string symbol2) =>
            $"https://cex.io/api/open_orders/{symbol1}/{symbol2}";

        internal static string CancelAllOrders(string symbol1, string symbol2) =>
            $"https://cex.io/api/cancel_orders/{symbol1}/{symbol2}";

        internal static string PlaceOrder(string symbol1, string symbol2) =>
            $"https://cex.io/api/place_order/{symbol1}/{symbol2}";

        internal static string CancelReplaceOrder(string symbol1, string symbol2) =>
            $"https://cex.io/api/cancel_replace_order/{symbol1}/{symbol2}";

        internal static string OpenPosition(string symbol1, string symbol2) =>
            $"https://cex.io/api/open_position/{symbol1}/{symbol2}";

        internal static string ClosePosition(string symbol1, string symbol2) =>
            $"https://cex.io/api/close_position/{symbol1}/{symbol2}";
        #endregion
    }
}
