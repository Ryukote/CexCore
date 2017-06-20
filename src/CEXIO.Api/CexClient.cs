using CEXIO.Api.Common;
using CEXIO.Api.Helpers;
using CEXIO.Api.MarketEntities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CEXIO.Api
{
    public class CexClient : IClient
    {
        private readonly ApiWebClient _client;

        public IAccount Account { get; set; }

        private ApiCredentials _credentials;
        public ApiCredentials Credentials
        {
            get => _credentials;
            set
            {
                _client.Credentials = value;
                _credentials = value;
            }
        }

        public CexClient(ApiCredentials credentials)
        {
            _credentials = credentials;

            _client = new ApiWebClient()
            {
                Credentials = _credentials
            };

            Account = new Account(_client);
        }

        public CexClient(string userId, string apiKey, string apiSecret) : 
            this(new ApiCredentials(userId, apiKey, apiSecret))
        {

        }

        public CexClient() : this(null)
        {
            
        }

        public Task<Ticker> GetTickerAsync(SymbolPairs pair, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            var command = Command.GetTicker.ToStringNormalized() + pair.ToStringNormalized();
            var ticker  = _client.GetDataAsync<Ticker>(command);

            return ticker;
        }

        public async Task<decimal> GetLastPriceAsync(SymbolPairs pair, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            var command   = Command.GetLastPrice.ToStringNormalized() + pair.ToStringNormalized();
            var json      = await _client.GetDataAsync(command);
            decimal price = json.Value<decimal>("lprice");

            return price;
        }

        public async Task<decimal> Convert(SymbolPairs pair, decimal amount, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            var parameters = new Dictionary<string, string>()
            {
                { "amnt",  amount.ToString() }
            };

            var command   = Command.Convert.ToStringNormalized() + pair.ToStringNormalized();
            var json      = await _client.PostDataAsync(command, parameters);

            var result        = JObject.Parse(json);
            decimal converted = result.Value<decimal>("amnt");

            return converted;
        }

        public Task<OrderBook> GetOrderBookAsync(SymbolPairs pair, int depth, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            var command   = Command.GetOrderBook.ToStringNormalized() + SymbolPairs.BTC_USD.ToStringNormalized() + "/?depth=" + depth;
            var orderbook = _client.GetDataAsync<OrderBook>(command);

            return orderbook;
        }

        public Task<IEnumerable<Trade>> GetTradeHistoryAsync(SymbolPairs pair, TradeId? since = default(TradeId?), CancellationToken? cancellationToken = default(CancellationToken?))
        {
            throw new NotImplementedException();
        }
    }
}
