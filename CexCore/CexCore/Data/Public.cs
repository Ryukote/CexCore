using CexCore.Common;
using CexCore.Contracts;
using CexCore.Exceptions;
using CexCore.Models.Common;
using CexCore.Models.Request;
using CexCore.Models.Response;
using CexCore.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static CexCore.Common.Symbols;

namespace CexCore.Data
{
    /// <summary>
    /// Public API methods.
    /// </summary>
    public class Public : IPublic
    {
        private CexHttpClient _client;

        public Public()
        {
            _client = new CexHttpClient();
        }

        /// <summary>
        /// Getting converted amount.
        /// </summary>
        /// <param name="symbol1">Pair symbol 1.</param>
        /// <param name="symbol2">Pair symbol 2.</param>
        /// <param name="converter">Instance of Converter.</param>
        /// <returns>Tuple of HttpStatusCode and Converter.</returns>
        public async Task<Tuple<HttpStatusCode, Converter>> GetConvertedAmount(string symbol1, string symbol2,
            Converter converter)
        {
            Tuple<HttpStatusCode, string> response;
            var json = JsonConvert.SerializeObject(converter);

            using (HttpContent content = new StringContent(json))
            {
                content.Headers.ContentType.MediaType = "application/json";
                response = await _client.PostAsync(PublicEndpoints.Converter(symbol1, symbol2), content);
            }

            var convertedResponse = ResponseConverter<Converter>.ConvertResponse(response);

            if (convertedResponse.Item2.Amount == null)
            {
                throw new CexNullException(CexExceptionMessages.CexNullCurrenciesException);
            }

            return convertedResponse;
        }

        /// <summary>
        /// Getting currency limits
        /// </summary>
        /// <returns>Tuple of HttpStatusCode and CurrencyLimitsResponse.</returns>
        public async Task<Tuple<HttpStatusCode, CurrencyLimitsResponse>> GetCurrencyLimitsAsync()
        {
            var response = await _client.GetAsync(PublicEndpoints.CurrencyLimits);
            return ResponseConverter<CurrencyLimitsResponse>.ConvertResponse(response);
        }

        /// <summary>
        /// Getting last price for given pair.
        /// </summary>
        /// <param name="currency1">Pair symbol 1.</param>
        /// <param name="currency2">Pair symbol 2.</param>
        /// <returns>Tuple of HttpStatusCode and LastPriceResponse.</returns>
        public async Task<Tuple<HttpStatusCode, LastPriceResponse>> GetLastPriceAsync(string currency1, string currency2)
        {
            var response = await _client.GetAsync(PublicEndpoints.LastPrice(currency1, currency2));

            var convertedResponse = ResponseConverter<LastPriceResponse>.ConvertResponse(response);

            if (convertedResponse.Item2.LastPrice == null)
            {
                throw new CexNullException(CexExceptionMessages.CexNullCurrenciesException);
            }

            return convertedResponse;
        }

        /// <summary>
        /// Getting last prices for given markets.
        /// </summary>
        /// <param name="listOfCrypto">Collection of CryptoCurrency enum.</param>
        /// <param name="listOfFiat">Collection of Fiat enum.</param>
        /// <returns>Tuple of HttpStatusCode and LastPriceForGivenMarketsResponse.</returns>
        public async Task<Tuple<HttpStatusCode, LastPriceForGivenMarketsResponse>> GetLastPricesForGivenMarketsAsync
            (ICollection<CryptoCurrency> listOfCrypto, ICollection<Fiat> listOfFiat)
        {
            var urlSuffix = UrlSuffix.GetUrlSuffix(listOfCrypto, listOfFiat);

            var response = await _client.GetAsync(PublicEndpoints.LastPricesForGivenMarkets + urlSuffix);

            return ResponseConverter<LastPriceForGivenMarketsResponse>.ConvertResponse(response);
        }

        /// <summary>
        /// Getting order book.
        /// </summary>
        /// <param name="orderBook">Instance of OrderBookRequest.</param>
        /// <returns>Tuple of HttpStatusCode and OrderBookResponse.</returns>
        public async Task<Tuple<HttpStatusCode, OrderBookResponse>> GetOrderBook(OrderBookRequest orderBook)
        {
            List<string> list = new List<string>();

            list.Add(orderBook.Symbol1);
            list.Add(orderBook.Symbol2);
            list.Add(orderBook.Depth.ToString());

            var urlSuffix = UrlSuffix.GetGeneralUrlSuffix(list);

            var response = await _client.GetAsync(PublicEndpoints.OrderBook + urlSuffix);

            return ResponseConverter<OrderBookResponse>.ConvertResponse(response);
        }

        /// <summary>
        /// Getting ticker for given enum pairs.
        /// </summary>
        /// <param name="cryptoCurrency">CryptoCurrency enum.</param>
        /// <param name="fiat">Fiat enum.</param>
        /// <returns>Tuple of HttpStatusCode and TickerResponse.</returns>
        public async Task<Tuple<HttpStatusCode, TickerResponse>> GetTickerAsync(CryptoCurrency cryptoCurrency, Fiat fiat)
        {
            var response = await _client.GetAsync(PublicEndpoints.Ticker(cryptoCurrency, fiat));
            return ResponseConverter<TickerResponse>.ConvertResponse(response);
        }

        /// <summary>
        /// Getting ticker for given enum pairs.
        /// </summary>
        /// <param name="cryptoCurrency">CryptoCurrency enum.</param>
        /// <param name="fiat">CryptoCurrency enum.</param>
        /// <returns>Tuple of HttpStatusCode and TickerResponse.</returns>
        public async Task<Tuple<HttpStatusCode, TickerResponse>> GetTickerAsync(CryptoCurrency cryptoCurrency1, CryptoCurrency cryptoCurrency2)
        {
            var response = await _client.GetAsync(PublicEndpoints.Ticker(cryptoCurrency1, cryptoCurrency2));
            return ResponseConverter<TickerResponse>.ConvertResponse(response);
        }

        /// <summary>
        /// Getting tickers for pairs by market.
        /// </summary>
        /// <param name="listOfCrypto">Collection of CryptoCurrency enum.</param>
        /// <param name="listOfFiat">Collection of Fiat enum.</param>
        /// <returns>Tuple of HttpStatusCode and TickersForPairsResponse.</returns>
        public async Task<Tuple<HttpStatusCode, TickersForPairsResponse>> GetTickersForPairsByMarketAsync
            (ICollection<Symbols.CryptoCurrency> listOfCrypto, ICollection<Symbols.Fiat> listOfFiat)
        {
            var urlSuffix = UrlSuffix.GetUrlSuffix(listOfCrypto, listOfFiat);

            var response = await _client.GetAsync(PublicEndpoints.TickersForAllPairsByMarkets + urlSuffix);

            return ResponseConverter<TickersForPairsResponse>.ConvertResponse(response);
        }

        /// <summary>
        /// Getting trade history.
        /// </summary>
        /// <param name="tradeHistory">Instance of TradeHistoryRequest.</param>
        /// <returns>Tuple of HttpStatusCode and TradeHistoryResponse.</returns>
        public async Task<Tuple<HttpStatusCode, TradeHistoryResponse>> GetTradeHistory(TradeHistoryRequest tradeHistory)
        {
            var symbol1 = tradeHistory.Symbol1;
            var symbol2 = tradeHistory.Symbol2;
            var since = tradeHistory.Since.ToString();

            var response = await _client.GetAsync(PublicEndpoints.TradeHistory(symbol1, symbol2, since));

            var convertedHistory = ResponseConverter<TradeHistory>.ConvertToArray(response.Item2);

            var tradeHistoryResponse = new TradeHistoryResponse()
            {
                TradeHistory = convertedHistory
            };

            return new Tuple<HttpStatusCode, TradeHistoryResponse>(response.Item1, tradeHistoryResponse);
        }
    }
}
