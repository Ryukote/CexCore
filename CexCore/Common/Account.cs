using CexCore.Data;
using CexCore.Helpers;
using CexCore.MarketEntities;
using CexCore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CexCore.Common
{
    public class Account : IAccount
    {
        private readonly ApiWebClient _client;

        public Account(ApiWebClient client)
        {
            _client = client;
        }

        public async Task<Tuple<HttpStatusCode, string>> CancelOrder(ulong orderId)
        {
            string json = string.Empty;
            var client = new CexHttpClient();

            var cancelOrder = new CancelOrder()
            {
                Id = orderId
            };

            try
            {
                json = JsonConvert.SerializeObject(cancelOrder);
            }
            catch(JsonException ex)
            {
                throw new JsonException("Your JSON is not valid.", ex);
            }

            using (HttpContent content = new StringContent(json))
            {
                try
                {
                    return await client.CexPostAsync(CexConstants.CancelOrderUrl, content);
                }
                catch(HttpRequestException ex)
                {
                    throw new HttpRequestException(CexConstants.HttpPostRequestException, ex);
                }
            }
        }

        public async Task<Tuple<HttpStatusCode, string>> CancelOrder(SymbolPairs pair)
        {
            var client = new CexHttpClient();

            var splittedPair    s = pair.ToString().Split('_');

            var cancelOrder = new CancelOrdersForGivenPair()
            {
                FirstCurrency = splittedPairs[0],
                SecondCurrency = splittedPairs[1]
            };

            var json = JsonConvert.SerializeObject(cancelOrder);

            using (HttpContent content = new StringContent(json))
            {
                return await client.CexPostAsync(CexConstants.CancelOrderUrl, content);
            }
        }

        public async Task<bool> ClosePosition(SymbolPairs pair, ulong positionId, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            var parameters = new Dictionary<string, string>()
            {
                { "id", positionId.ToString() }
            };

            var command = Command.ClosePosition.ToString().Normalize() + pair.ToString().Normalize();
            await _client.PostDataAsync(command, parameters);

            return true;
        }

        public async Task<string> GetAddressAsync(Symbols symbol, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            var parameters = new Dictionary<string, string>()
            {
                { "currency", Symbols.BTC.ToString() }
            };

            var command = Command.GetAddress.ToString().Normalize();
            var json = await _client.PostDataAsync(command, parameters);
            var addr = JObject.Parse(json).Value<string>("data");

            return addr;
        }

        public async Task<Balance> GetBalanceAsync()
        {
            var balance = await _client.PostDataAsync<Balance>("balance", null);
            return balance;
        }

        public async Task<IEnumerable<Order>> GetOpenOrdersAsync(SymbolPairs pair, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            var command = Command.GetOpenOrders.ToString().Normalize() + pair.ToString().Normalize();
            var json = await _client.PostDataAsync(command, null);

            var orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(json);
            return orders;
        }

        public async Task<IEnumerable<Position>> GetOpenPositonsAsync(SymbolPairs pair, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            var command = Command.GetOpenPositions.ToString().Normalize() + pair.ToString().Normalize();
            var json = await _client.PostDataAsync(command, null);
            var jarr = JObject.Parse(json).Value<JArray>("data");

            IEnumerable<Position> positions = null;

            if (jarr.Count > 0)
                positions = (IEnumerable<Position>)jarr;

            return positions;
        }

        public async Task<long> OpenPosition(Position position, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            var parameters = new Dictionary<string, string>()
            {
                { "amount", position.Amount.ToString(CultureInfo.InvariantCulture) },
                { "symbol", position.Symbol.ToString() },
                { "leverage", position.Leverage.ToString() },
                { "ptype", position.Type.ToString().Normalize() },
                { "anySlippage", position.AnySlippage.ToString().ToLower() },
                { "eoprice", position.EstimatedOpenPrice.ToString(CultureInfo.InvariantCulture) },
                { "stopLossPrice", position.StopLossPrice.ToString(CultureInfo.InvariantCulture) }
            };

            var command = Command.OpenPosition.ToString().Normalize() + position.Pair.ToString().Normalize();
            var json = await _client.PostDataAsync(command, parameters);
            var positions = JObject.Parse(json).Value<JObject>("data");

            if (!positions.HasValues)
                return -1;

            return positions.Value<long>("id");

        }

        public async Task<Order> PlaceLimitOrder(Order order, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            var parameters = new Dictionary<string, string>()
            {
                { "type", order.Type.ToString().Normalize() },
                { "amount", order.Amount.ToString(CultureInfo.InvariantCulture) },
                { "price", order.Price.ToString(CultureInfo.InvariantCulture) }
            };

            var command = Command.PlaceOrder.ToString().Normalize() + order.Pair.ToString().Normalize();
            var result = await _client.PostDataAsync<Order>(command, parameters);

            return result;
        }

        public async Task<Order> PlaceMarketOrder(Order order, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            var parameters = new Dictionary<string, string>()
            {
                { "type", order.Type.ToString().Normalize() },
                { "amount", order.Amount.ToString(CultureInfo.InvariantCulture) },
                { "order_type", "market" }
            };

            char[] delimiter = { '_' };
            string[] splitPairs = order.Pair.ToString().Split(delimiter);

            var url = "place_order/" + splitPairs[1] + "/" + splitPairs[0];

            //var command = Command.PlaceOrder.ToString() + order.Pair.ToString();
            var result = await _client.PostDataAsync<Order>(url, parameters);

            return result;
        }
    }
}
