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
        private ApiCredentials _credentials;
        private string _apiSecret;

        public Account(ApiCredentials credentials, string apiSecret)
        {
            _credentials = credentials;
            _apiSecret = apiSecret;
        }

        public async Task<CancelOrderResponse> CancelOrder(CancelOrder cancelOrder)
        {
            string json = string.Empty;

            var client = new CexHttpClient();

            try
            {
                json = JsonConvert.SerializeObject(cancelOrder);
            }
            catch(JsonException ex)
            {
                throw new JsonException(CexConstants.InvalidJsonException, ex);
            }

            using (HttpContent content = new StringContent(json))
            {
                try
                {
                    var responseObject = await client.CexPostAsync(CexConstants.CancelOrderUrl, content);

                    return new CancelOrderResponse()
                    {
                        StatusCode = responseObject.Item1
                    };
                }
                catch(HttpRequestException ex)
                {
                    throw new HttpRequestException(CexConstants.HttpPostRequestException, ex);
                }
            }
        }

        public async Task<CancelOrdersForGivenPairResponse> CancelOrdersForGivePair(SymbolPairs pair, EmptyPrivateRequest baseRequest)
        {
            string json = string.Empty;

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

            using (HttpContent content = new StringContent(JsonConvert.SerializeObject(baseRequest)))
            {
                var responseObject = await client.CexPostAsync(CexConstants.CacelAllOrderWithPairsUrl(splittedPairs[0], splittedPairs[1]), content);

                var response = JsonConvert.DeserializeObject<CancelOrdersForGivenPairResponse>(responseObject.Item2);
                response.StatusCode = responseObject.Item1;

                return response;
            }
        }

        public async Task<ClosePositionResponse> ClosePosition(SymbolPairs pair, ulong positionId)
        {
            var client = new CexHttpClient();

            var splittedPairs = pair.ToString().Split('_');

            var positionRequest = new PositionRequest(_apiSecret)
            {
                Key = _credentials.ApiKey,
                PositionId = positionId
            };

            using (HttpContent content = new StringContent(JsonConvert.SerializeObject(JsonConvert.SerializeObject(positionRequest))))
            {
                var responseObject = await client.CexPostAsync(CexConstants.ClosePositionUrl(splittedPairs[0], splittedPairs[1]), content);

                var response = JsonConvert.DeserializeObject<ClosePositionResponse>(responseObject.Item2);
                response.StatusCode = responseObject.Item1;

                return response;
            }
        }

        public async Task<Tuple<HttpStatusCode, string>> GetAddressAsync(Symbols symbol)
        {
            var client = new CexHttpClient();

            var addressRequest = new AddressRequest(_hmac)
            {
                Key = _credentials.ApiKey,
                Currency = symbol.ToString()
            };

            using (HttpContent content = new StringContent(JsonConvert.SerializeObject(JsonConvert.SerializeObject(addressRequest))))
            {
                return await client.CexPostAsync(CexConstants.CryptoAddressUrl, content);
            }
        }

        public async Task<Tuple<HttpStatusCode, string>> GetBalanceAsync()
        {
            var client = new CexHttpClient();

            var balanceRequest = new EmptyPrivateRequest(_hmac)
            {
                Key = _credentials.ApiKey
            };

            using (HttpContent content = new StringContent(JsonConvert.SerializeObject(JsonConvert.SerializeObject(balanceRequest))))
            {
                return await client.CexPostAsync(CexConstants.BalanceUrl, content);
            }
        }

        public async Task<Tuple<HttpStatusCode, string>> GetOpenOrdersAsync()
        {
            var client = new CexHttpClient();

            var openOrders = new EmptyPrivateRequest(_hmac)
            {
                Key = _credentials.ApiKey
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

            var openOrders = new EmptyPrivateRequest(_hmac)
            {
                Key = _credentials.ApiKey
            };

            using (HttpContent content = new StringContent(JsonConvert.SerializeObject(JsonConvert.SerializeObject(openOrders))))
            {
                return await client.CexPostAsync(CexConstants.OpenOrdersByPairUrl(splittedPairs[0], splittedPairs[1]), content);
            }
        }

        public async Task<Tuple<HttpStatusCode, string>> GetOpenPositonsAsync(SymbolPairs pair)
        {
            var client = new CexHttpClient();

            var splittedPairs = pair.ToString().Split('_');

            var openPosition = new OpenPositionOrderRequest(_hmac)
            {
                Key = _credentials.ApiKey
            };

            using (HttpContent content = new StringContent(JsonConvert.SerializeObject(JsonConvert.SerializeObject(openPosition))))
            {
                return await client.CexPostAsync(CexConstants.OpenPositionUrl(splittedPairs[0], splittedPairs[1]), content);
            }
        }

        public async Task<Tuple<HttpStatusCode, string>> GetPosition(Position position)
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
