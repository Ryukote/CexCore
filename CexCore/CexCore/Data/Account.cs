﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CexCore.Common;
using CexCore.Contracts;
using CexCore.Models.Common;
using CexCore.Models.Request;
using CexCore.Models.Response;
using CexCore.Utilities;
using Newtonsoft.Json;

namespace CexCore.Data
{
    /// <summary>
    /// User account information.
    /// </summary>
    public class Account : IAccount
    {
        private CexHttpClient _client;

        public Account()
        {
            _client = new CexHttpClient();
        }

        /// <summary>
        /// Getting account balance.
        /// </summary>
        /// <param name="balance">Instance of AccountBalanceRequest.</param>
        /// <returns>Tuple of HttpStatusCode and AccountBalanceResponse.</returns>
        public async Task<Tuple<HttpStatusCode, AccountBalanceResponse>> GetAccountBalanceAsync(AccountBalanceRequest balance)
        {
            var json = JsonConvert.SerializeObject(balance);

            using (HttpContent content = new StringContent(json))
            {
                var response = await _client.PostAsync(AccountEndpoints.AccountBalance, content);
                return ResponseConverter<AccountBalanceResponse>.ConvertResponse(response);
            }
        }

        /// <summary>
        /// Getting open orders.
        /// </summary>
        /// <param name="request">Instance of BaseRequest.</param>
        /// <returns>Tuple of HttpStatusCode and OpenOrdersResponse.</returns>
        public async Task<Tuple<HttpStatusCode, OpenOrdersResponse>> GetOpenOrdersAsync(BaseRequest request)
        {
            var json = JsonConvert.SerializeObject(request);

            using (HttpContent content = new StringContent(json))
            {
                var response = await _client.PostAsync(AccountEndpoints.OpenOrders, content);

                var convertedResponse = ResponseConverter<OpenOrders>.ConvertToArray(response.Item2);

                var openOrders = new OpenOrdersResponse()
                {
                    OpenOrders = convertedResponse
                };

                return new Tuple<HttpStatusCode, OpenOrdersResponse>(response.Item1, openOrders);
            }
        }

        /// <summary>
        /// Getting open orders by pair.
        /// </summary>
        /// <param name="symbol1">Pair symbol 1.</param>
        /// <param name="symbol2">Pair symbol 2.</param>
        /// <param name="request">Instance of BaseRequest.</param>
        /// <returns>Tuple of HttpStatusCode and OpenOrdersResponse.</returns>
        public async Task<Tuple<HttpStatusCode, OpenOrdersResponse>> GetOpenOrdersByPairAşync(string symbol1, string symbol2, BaseRequest request)
        {
            var json = JsonConvert.SerializeObject(request);

            using (HttpContent content = new StringContent(json))
            {
                var response = await _client.PostAsync(AccountEndpoints.OpenOrdersByPair(symbol1, symbol2), content);

                var convertedResponse = ResponseConverter<OpenOrders>.ConvertToArray(response.Item2);

                var openOrders = new OpenOrdersResponse()
                {
                    OpenOrders = convertedResponse
                };

                return new Tuple<HttpStatusCode, OpenOrdersResponse>(response.Item1, openOrders);
            }
        }

        /// <summary>
        /// Getting active order status.
        /// </summary>
        /// <param name="request">Instance of ActiveOrderStatusRequest.</param>
        /// <returns>Tuple of HttpStatusCode and ActiveOrderStatusResponse.</returns>
        public async Task<Tuple<HttpStatusCode, ActiveOrderStatusResponse>> GetActiveOrderStatusAşync(ActiveOrderStatusRequest request)
        {
            var json = JsonConvert.SerializeObject(request);

            using (HttpContent content = new StringContent(json))
            {
                var response = await _client.PostAsync(AccountEndpoints.ActiveOrderStatus, content);

                var convertedResponse = ResponseConverter<ActiveOrderStatusResponse>.ConvertResponse(response);

                return new Tuple<HttpStatusCode, ActiveOrderStatusResponse>(response.Item1, convertedResponse.Item2);
            }
        }

        /// <summary>
        /// Cancel order method.
        /// </summary>
        /// <param name="request">Instance of CancelOrderRequest.</param>
        /// <returns>Tuple of HttpStatusCode and CancelOrderResponse.</returns>
        public async Task<Tuple<HttpStatusCode, CancelOrderResponse>> CancelOrderAşync(CancelOrderRequest request)
        {
            var json = JsonConvert.SerializeObject(request);

            using (HttpContent content = new StringContent(json))
            {
                var response = await _client.PostAsync(AccountEndpoints.CancelOrder, content);

                var convertedResponse = ResponseConverter<CancelOrderResponse>.ConvertResponse(response);

                return new Tuple<HttpStatusCode, CancelOrderResponse>(response.Item1, convertedResponse.Item2);
            }
        }

        /// <summary>
        /// Cancel order for given pair.
        /// </summary>
        /// <param name="symbol1">Pair symbol 1.</param>
        /// <param name="symbol2">Pair symbol 2.</param>
        /// <param name="request">Instance of BaseRequest.</param>
        /// <returns>Tuple of HttpStatusCode and CancelAllOrdersForGivenPairResponse.</returns>
        public async Task<Tuple<HttpStatusCode, CancelAllOrdersForGivenPairResponse>> CancelOrdersForGivenPairAşync(string symbol1, string symbol2, BaseRequest request)
        {
            var json = JsonConvert.SerializeObject(request);

            using (HttpContent content = new StringContent(json))
            {
                var response = await _client.PostAsync(AccountEndpoints.CancelAllOrders(symbol1, symbol2), content);

                var convertedResponse = ResponseConverter<CancelAllOrdersForGivenPairResponse>.ConvertResponse(response);

                return new Tuple<HttpStatusCode, CancelAllOrdersForGivenPairResponse>(response.Item1, convertedResponse.Item2);
            }
        }

        /// <summary>
        /// Place order.
        /// </summary>
        /// <param name="symbol1">Pair symbol 1.</param>
        /// <param name="symbol2">Pair symbol 2.</param>
        /// <param name="request">Instance of PlaceOrderRequest.</param>
        /// <returns>Tuple of HttpStatusCode and PlaceOrderResponse.</returns>
        public async Task<Tuple<HttpStatusCode, PlaceOrderResponse>> PlaceOrderAşync(string symbol1, string symbol2, PlaceOrderRequest request)
        {
            var json = JsonConvert.SerializeObject(request);

            using (HttpContent content = new StringContent(json))
            {
                var response = await _client.PostAsync(AccountEndpoints.PlaceOrder(symbol1, symbol2), content);

                var convertedResponse = ResponseConverter<PlaceOrderResponse>.ConvertResponse(response);

                return new Tuple<HttpStatusCode, PlaceOrderResponse>(response.Item1, convertedResponse.Item2);
            }
        }

        /// <summary>
        /// Getting crypto address.
        /// </summary>
        /// <param name="addressRequest">Instance of CryptoAddressRequest.</param>
        /// <returns>Tuple of HttpStatusCode and CryptoAddressResponse.</returns>
        public async Task<Tuple<HttpStatusCode, CryptoAddressResponse>> GetCryptoAddressAşync(CryptoAddressRequest addressRequest)
        {
            var json = JsonConvert.SerializeObject(addressRequest);

            using (HttpContent content = new StringContent(json))
            {
                var response = await _client.PostAsync(AccountEndpoints.CryptoAddress, content);

                var convertedResponse = ResponseConverter<CryptoAddressResponse>.ConvertResponse(response);

                return new Tuple<HttpStatusCode, CryptoAddressResponse>(response.Item1, convertedResponse.Item2);
            }
        }

        /// <summary>
        /// Getting fee's for all pairs.
        /// </summary>
        /// <param name="request">Instance of BaseRequest.</param>
        /// <returns>Tuple of HttpStatusCode and GetMyFeeResponse.</returns>
        public async Task<Tuple<HttpStatusCode, GetMyFeeResponse>> GetMyFeeAşync(BaseRequest request)
        {
            var json = JsonConvert.SerializeObject(request);

            using (HttpContent content = new StringContent(json))
            {
                var response = await _client.PostAsync(AccountEndpoints.GetMyFee, content);

                var convertedResponse = ResponseConverter<GetMyFeeResponse>.ConvertResponse(response);

                return new Tuple<HttpStatusCode, GetMyFeeResponse>(response.Item1, convertedResponse.Item2);
            }
        }

        /// <summary>
        /// Cancel replace order.
        /// </summary>
        /// <param name="symbol1">Pair symbol 1.</param>
        /// <param name="symbol2">Pair symbol 2.</param>
        /// <param name="request">Instance of CancelReplaceOrderRequest.</param>
        /// <returns>Tuple of HttpStatusCode and CancelReplaceOrderResponse.</returns>
        public async Task<Tuple<HttpStatusCode, CancelReplaceOrderResponse>> CancelReplaceOrderAsync(string symbol1, string symbol2, CancelReplaceOrderRequest request)
        {
            var json = JsonConvert.SerializeObject(request);

            using (HttpContent content = new StringContent(json))
            {
                var response = await _client.PostAsync(AccountEndpoints.CancelReplaceOrder(symbol1, symbol2), content);

                var convertedResponse = ResponseConverter<CancelReplaceOrderResponse>.ConvertResponse(response);

                return new Tuple<HttpStatusCode, CancelReplaceOrderResponse>(response.Item1, convertedResponse.Item2);
            }
        }

        /// <summary>
        /// Open position for given pair.
        /// </summary>
        /// <param name="symbol1">Pair symbol 1.</param>
        /// <param name="symbol2">Pair symbol 2.</param>
        /// <param name="request">Instance of OpenPositionOrderRequest.</param>
        /// <returns>Tuple of HttpStatusCode and OpenPositionOrderResponse.</returns>
        public async Task<Tuple<HttpStatusCode, OpenPositionOrderResponse>> OpenPositionAsync(string symbol1, string symbol2, OpenPositionOrderRequest request)
        {
            var json = JsonConvert.SerializeObject(request);

            using (HttpContent content = new StringContent(json))
            {
                var response = await _client.PostAsync(AccountEndpoints.OpenPosition(symbol1, symbol2), content);

                var convertedResponse = ResponseConverter<OpenPositionOrderResponse>.ConvertResponse(response);

                return new Tuple<HttpStatusCode, OpenPositionOrderResponse>(response.Item1, convertedResponse.Item2);
            }
        }

        /// <summary>
        /// Close position for given pair.
        /// </summary>
        /// <param name="symbol1">Pair symbol 1.</param>
        /// <param name="symbol2">Pair symbol 2.</param>
        /// <param name="request">Instance of ClosePositionRequest.</param>
        /// <returns>Tuple of HttpStatusCode and ClosePositionResponse.</returns>
        public async Task<Tuple<HttpStatusCode, ClosePositionResponse>> ClosePositionAsync(string symbol1, string symbol2, ClosePositionRequest request)
        {
            var json = JsonConvert.SerializeObject(request);

            using (HttpContent content = new StringContent(json))
            {
                var response = await _client.PostAsync(AccountEndpoints.ClosePosition(symbol1, symbol2), content);

                var convertedResponse = ResponseConverter<ClosePositionResponse>.ConvertResponse(response);

                return new Tuple<HttpStatusCode, ClosePositionResponse>(response.Item1, convertedResponse.Item2);
            }
        }
    }
}