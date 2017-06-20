using CEXIO.Api.MarketEntities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CEXIO.Api
{
    public interface IClient
    {
        Task<Ticker> GetTickerAsync(SymbolPairs pair, CancellationToken? cancellationToken = null);
        Task<decimal> GetLastPriceAsync(SymbolPairs pair, CancellationToken? cancellationToken = null);
        Task<decimal> Convert(SymbolPairs pair, decimal amount, CancellationToken? cancellationToken = null);
        Task<OrderBook> GetOrderBookAsync(SymbolPairs pair, int depth, CancellationToken? cancellationToken = null);
        Task<IEnumerable<Trade>> GetTradeHistoryAsync(SymbolPairs pair, TradeId? since = null, CancellationToken? cancellationToken = null);
    }
}
