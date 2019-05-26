using CexCore.MarketEntities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CexCore.Common
{
    public interface IAccount
    {
        Task<Balance> GetBalanceAsync();
        Task<IEnumerable<Order>> GetOpenOrdersAsync(SymbolPairs pair, CancellationToken? cancellationToken = null);
        Task<bool> CancelOrder(ulong orderId, CancellationToken? cancellationToken = null);
        Task<bool> CancelOrder(SymbolPairs pair, CancellationToken? cancellationToken = null);
        Task<Order> PlaceLimitOrder(Order order, CancellationToken? cancellationToken = null);
        Task<Order> PlaceMarketOrder(Order order, CancellationToken? cancellationToken = null);
        Task<long> OpenPosition(Position position, CancellationToken? cancellationToken = null);
        Task<string> GetAddressAsync(Symbols symbol, CancellationToken? cancellationToken = null);
        Task<IEnumerable<Position>> GetOpenPositonsAsync(SymbolPairs pair, CancellationToken? cancellationToken = null);
        Task<bool> ClosePosition(SymbolPairs pair, ulong positionId, CancellationToken? cancellationToken = null);
    }
}
