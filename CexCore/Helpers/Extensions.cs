using CexCore.MarketEntities;

namespace CexCore.Helpers
{
    public static class Extensions
    {
        internal static string ToStringNormalized(this SymbolPairs value)
        {
            return value.ToString().Replace('_', '/');
        }

        internal static string ToStringNormalized(this OrderType value)
        {
            switch (value)
            {
                case OrderType.Buy:
                    return "buy";
                case OrderType.Sell:
                    return "sell";
                default:
                    return string.Empty;
            }
        }

        internal static string ToStringNormalized(this PositionType value)
        {
            switch (value)
            {
                case PositionType.Long:
                    return "long";

                case PositionType.Short:
                    return "short";

                default:
                    return string.Empty;
            }
        }

        internal static string ToStringNormalized(this Command value)
        {
            switch (value)
            {
                case Command.GetTicker:
                    return "ticker/";
                case Command.GetLastPrice:
                    return "last_price/";
                case Command.GetBalance:
                    return "balance/";
                case Command.GetOpenOrders:
                    return "open_orders/";
                case Command.CancelOrder:
                    return "cancel_order/";
                case Command.CancelAll:
                    return "cancel_orders/";
                case Command.CancelReplaceOrder:
                    return "cancel_replace_order/";
                case Command.PlaceOrder:
                    return "place_order/";
                case Command.OpenPosition:
                    return "open_position/";
                case Command.GetAddress:
                    return "get_address/";
                case Command.GetOpenPositions:
                    return "open_positions/";
                case Command.ClosePosition:
                    return "close_position/";
                case Command.Convert:
                    return "convert/";
                case Command.Order_Book:
                    return "order_book/";
                case Command.GetTradeHistory:
                    return "trade_history/";
                default:
                    return null;
            }
        }
    }
}
