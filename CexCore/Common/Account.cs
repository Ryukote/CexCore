using CexCore.Data;
using CexCore.Helpers;
using CexCore.MarketEntities;
using CexCore.Models;
using CexCore.Models.Request;
using CexCore.Models.Response;
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
        private readonly ApiCredentials _credentials;
        private readonly string _apiSecret;
        private readonly ApiWebClient _client;

        public Account(ApiCredentials credentials, string apiSecret)
        {
            _credentials = credentials;
            _apiSecret = apiSecret;
            _client = new ApiWebClient
            {
                Credentials = credentials
            };
        }

        public Account(ApiWebClient client)
        {
            _client = client ?? new ApiWebClient();
            _credentials = _client.Credentials;
            _apiSecret = string.Empty;
        }

        public async Task<CancelOrderResponse> CancelOrder(CancelOrder cancelOrder)
        {
            string json;
            var client = new CexHttpClient();

            try
            {
                json = JsonConvert.SerializeObject(cancelOrder);
            }
            catch (JsonException ex)
            {
                throw new JsonException(CexConstants.InvalidJsonException, ex);
            }

            using (HttpContent content = new StringContent(json))
            {
                try
                {
                    var responseObject = await client.CexPostAsync(CexConstants.CancelOrderUrl, content);

                    return new CancelOrderResponse
                    {
                        StatusCode = responseObject.Item1
                    };
                }
                catch (HttpRequestException ex)
                {
                    throw new HttpRequestException(CexConstants.HttpPostRequestException, ex);
                }
            }
        }

        public async Task<CancelOrdersForGivenPairResponse> CancelOrdersForGivePair(SymbolPairs pair, EmptyPrivateRequest baseRequest)
        {
            string json;
            var client = new CexHttpClient();

            try
            {
                json = JsonConvert.SerializeObject(baseRequest);
            }
            catch (JsonException ex)
            {
                throw new JsonException(CexConstants.InvalidJsonException, ex);
            }

            var splittedPairs = pair.ToString().Split('_');
            var symbol1 = splittedPairs[0].ToApiSymbol();
            var symbol2 = splittedPairs[1].ToApiSymbol();

            using (HttpContent content = new StringContent(JsonConvert.SerializeObject(baseRequest)))
            {
                var responseObject = await client.CexPostAsync(CexConstants.CacelAllOrderWithPairsUrl(symbol1, symbol2), content);

                var response = JsonConvert.DeserializeObject<CancelOrdersForGivenPairResponse>(responseObject.Item2);
                response.StatusCode = responseObject.Item1;

                return response;
            }
        }

        public async Task<ClosePositionResponse> ClosePosition(SymbolPairs pair, ulong positionId)
        {
            var client = new CexHttpClient();
            var splittedPairs = pair.ToString().Split('_');
            var symbol1 = splittedPairs[0].ToApiSymbol();
            var symbol2 = splittedPairs[1].ToApiSymbol();

            var positionRequest = new PositionRequest(_apiSecret)
            {
                Key = _credentials?.ApiKey,
                PositionId = positionId
            };

            using (HttpContent content = new StringContent(JsonConvert.SerializeObject(JsonConvert.SerializeObject(positionRequest))))
            {
                var responseObject = await client.CexPostAsync(CexConstants.ClosePositionUrl(symbol1, symbol2), content);

                var response = JsonConvert.DeserializeObject<ClosePositionResponse>(responseObject.Item2);
                response.StatusCode = responseObject.Item1;

                return response;
            }
        }

        public async Task<Tuple<HttpStatusCode, string>> GetAddressAsync(Symbols symbol)
        {
            var client = new CexHttpClient();

            var addressRequest = new AddressRequest(_apiSecret)
            {
                Key = _credentials?.ApiKey,
                Currency = symbol.ToApiSymbol()
            };

            using (HttpContent content = new StringContent(JsonConvert.SerializeObject(JsonConvert.SerializeObject(addressRequest))))
            {
                return await client.CexPostAsync(CexConstants.CryptoAddressUrl, content);
            }
        }

        public async Task<Tuple<HttpStatusCode, string>> GetBalanceAsync()
        {
            var client = new CexHttpClient();

            var balanceRequest = new EmptyPrivateRequest(_apiSecret)
            {
                Key = _credentials?.ApiKey
            };

            using (HttpContent content = new StringContent(JsonConvert.SerializeObject(JsonConvert.SerializeObject(balanceRequest))))
            {
                return await client.CexPostAsync(CexConstants.BalanceUrl, content);
            }
        }

        public async Task<Tuple<HttpStatusCode, string>> GetOpenOrdersAsync()
        {
            var client = new CexHttpClient();

            var openOrders = new EmptyPrivateRequest(_apiSecret)
            {
                Key = _credentials?.ApiKey
            };

            using (HttpContent content = new StringContent(JsonConvert.SerializeObject(JsonConvert.SerializeObject(openOrders))))
            {
                return await client.CexPostAsync(CexConstants.OpenOrdersUrl, content);
            }
        }

        public async Task<Tuple<HttpStatusCode, string>> GetOpenOrdersByPairAsync(SymbolPairs pair)
        {
            var client = new CexHttpClient();
            var splittedPairs = pair.ToString().Split('_');
            var symbol1 = splittedPairs[0].ToApiSymbol();
            var symbol2 = splittedPairs[1].ToApiSymbol();

            var openOrders = new EmptyPrivateRequest(_apiSecret)
            {
                Key = _credentials?.ApiKey
            };

            using (HttpContent content = new StringContent(JsonConvert.SerializeObject(JsonConvert.SerializeObject(openOrders))))
            {
                return await client.CexPostAsync(CexConstants.OpenOrdersByPairUrl(symbol1, symbol2), content);
            }
        }

        public async Task<Tuple<HttpStatusCode, string>> GetOpenPositonsAsync(SymbolPairs pair)
        {
            var client = new CexHttpClient();
            var splittedPairs = pair.ToString().Split('_');
            var symbol1 = splittedPairs[0].ToApiSymbol();
            var symbol2 = splittedPairs[1].ToApiSymbol();

            var openPosition = new OpenPositionOrderRequest(_apiSecret)
            {
                Key = _credentials?.ApiKey
            };

            using (HttpContent content = new StringContent(JsonConvert.SerializeObject(JsonConvert.SerializeObject(openPosition))))
            {
                return await client.CexPostAsync(CexConstants.OpenPositionUrl(symbol1, symbol2), content);
            }
        }

        public async Task<long> OpenPosition(Position position, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            var parameters = new Dictionary<string, string>
            {
                { "amount", position.Amount.ToString(CultureInfo.InvariantCulture) },
                { "symbol", position.Symbol.ToApiSymbol() },
                { "leverage", position.Leverage.ToString() },
                { "ptype", position.Type.ToStringNormalized() },
                { "anySlippage", position.AnySlippage.ToString().ToLowerInvariant() },
                { "eoprice", position.EstimatedOpenPrice.ToString(CultureInfo.InvariantCulture) },
                { "stopLossPrice", position.StopLossPrice.ToString(CultureInfo.InvariantCulture) }
            };

            var command = Command.OpenPosition.ToStringNormalized() + position.Pair.ToStringNormalized();
            var json = await _client.PostDataAsync(command, parameters, cancellationToken);
            var positions = JObject.Parse(json).Value<JObject>("data");

            if (positions == null || !positions.HasValues)
                return -1;

            return positions.Value<long>("id");
        }

        public async Task<Order> PlaceLimitOrder(Order order, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            var parameters = new Dictionary<string, string>
            {
                { "type", order.Type.ToStringNormalized() },
                { "amount", order.Amount.ToString(CultureInfo.InvariantCulture) },
                { "price", order.Price.ToString(CultureInfo.InvariantCulture) }
            };

            var command = Command.PlaceOrder.ToStringNormalized() + order.Pair.ToStringNormalized();
            var result = await _client.PostDataAsync<Order>(command, parameters, cancellationToken);

            return result;
        }

        public async Task<Order> PlaceMarketOrder(Order order, CancellationToken? cancellationToken = default(CancellationToken?))
        {
            var parameters = new Dictionary<string, string>
            {
                { "type", order.Type.ToStringNormalized() },
                { "amount", order.Amount.ToString(CultureInfo.InvariantCulture) },
                { "order_type", "market" }
            };

            char[] delimiter = { '_' };
            string[] splitPairs = order.Pair.ToString().Split(delimiter);
            string symbol1 = splitPairs[0].ToApiSymbol();
            string symbol2 = splitPairs[1].ToApiSymbol();

            var url = "place_order/" + symbol2 + "/" + symbol1;
            var result = await _client.PostDataAsync<Order>(url, parameters, cancellationToken);

            return result;
        }

        async Task<Balance> IAccount.GetBalanceAsync()
        {
            var response = await GetBalanceAsync();
            var balance = JsonConvert.DeserializeObject<Balance>(response.Item2);
            return balance;
        }

        async Task<IEnumerable<Order>> IAccount.GetOpenOrdersAsync(SymbolPairs pair, CancellationToken? cancellationToken)
        {
            var response = await GetOpenOrdersByPairAsync(pair);
            var orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(response.Item2);
            return orders ?? Array.Empty<Order>();
        }

        async Task<Tuple<HttpStatusCode, string>> IAccount.CancelOrder(ulong orderId)
        {
            var request = new CancelOrder
            {
                Id = orderId
            };

            var response = await CancelOrder(request);
            return new Tuple<HttpStatusCode, string>(response.StatusCode, string.Empty);
        }

        async Task<Tuple<HttpStatusCode, string>> IAccount.CancelOrder(SymbolPairs pair)
        {
            var request = new EmptyPrivateRequest(_apiSecret)
            {
                Key = _credentials?.ApiKey
            };

            var response = await CancelOrdersForGivePair(pair, request);
            return new Tuple<HttpStatusCode, string>(response.StatusCode, JsonConvert.SerializeObject(response));
        }

        Task<Order> IAccount.PlaceLimitOrder(Order order, CancellationToken? cancellationToken)
        {
            return PlaceLimitOrder(order, cancellationToken);
        }

        Task<Order> IAccount.PlaceMarketOrder(Order order, CancellationToken? cancellationToken)
        {
            return PlaceMarketOrder(order, cancellationToken);
        }

        Task<long> IAccount.OpenPosition(Position position, CancellationToken? cancellationToken)
        {
            return OpenPosition(position, cancellationToken);
        }

        async Task<string> IAccount.GetAddressAsync(Symbols symbol, CancellationToken? cancellationToken)
        {
            var response = await GetAddressAsync(symbol);
            return response.Item2;
        }

        async Task<IEnumerable<Position>> IAccount.GetOpenPositonsAsync(SymbolPairs pair, CancellationToken? cancellationToken)
        {
            var response = await GetOpenPositonsAsync(pair);
            var positions = JsonConvert.DeserializeObject<IEnumerable<Position>>(response.Item2);
            return positions ?? Array.Empty<Position>();
        }

        async Task<Tuple<HttpStatusCode, string>> IAccount.ClosePosition(SymbolPairs pair, ulong positionId)
        {
            var response = await ClosePosition(pair, positionId);
            return new Tuple<HttpStatusCode, string>(response.StatusCode, JsonConvert.SerializeObject(response));
        }
    }
}
