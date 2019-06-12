using CexCore.Common;
using CexCore.Contracts;
using CexCore.Exceptions;
using CexCore.Models.Common;
using CexCore.Models.Response;
using CexCore.Utilities;
using Newtonsoft.Json;
using System;
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

        public async Task<Tuple<HttpStatusCode, Converter>> GetConvertedAmount(string symbol1, string symbol2,
            Converter converter)
        {
            Tuple<HttpStatusCode, string> response;
            var json = JsonConvert.SerializeObject(converter);

            using(HttpContent content = new StringContent(json))
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

        public async Task<Tuple<HttpStatusCode, CurrencyLimitsResponse>> GetCurrencyLimitsAsync()
        {
            var response = await _client.GetAsync(PublicEndpoints.CurrencyLimits);
            return ResponseConverter<CurrencyLimitsResponse>.ConvertResponse(response);
        }

        public async Task<Tuple<HttpStatusCode, LastPriceResponse>> GetLastPriceAsync(string currency1, string currency2)
        {
            var response = await _client.GetAsync(PublicEndpoints.LastPrice(currency1, currency2));

            var convertedResponse = ResponseConverter<LastPriceResponse>.ConvertResponse(response);

            if(convertedResponse.Item2.LastPrice == null)
            {
                throw new CexNullException(CexExceptionMessages.CexNullCurrenciesException);
            }

            return convertedResponse;
        }

        public async Task<Tuple<HttpStatusCode, LastPriceForGivenMarketsResponse>> GetLastPricesForGivenMarketsAsync
            (ICollection<CryptoCurrency> listOfCrypto, ICollection<Fiat> listOfFiat)
        {
            var afterUrl = AfterUrl.GetAfterUrl(listOfCrypto, listOfFiat);

            var response = await _client.GetAsync(PublicEndpoints.LastPricesForGivenMarkets + afterUrl);

            return ResponseConverter<LastPriceForGivenMarketsResponse>.ConvertResponse(response);
        }

        public async Task<Tuple<HttpStatusCode, TickerResponse>> GetTickerAsync(CryptoCurrency cryptoCurrency, Fiat fiat)
        {
            var response = await _client.GetAsync(PublicEndpoints.Ticker(cryptoCurrency, fiat));
            return ResponseConverter<TickerResponse>.ConvertResponse(response);
        }

        public async Task<Tuple<HttpStatusCode, TickersForPairsResponse>> GetTickersForPairsByMarketAsync
            (ICollection<Symbols.CryptoCurrency> listOfCrypto, ICollection<Symbols.Fiat> listOfFiat)
        {
            var afterUrl = AfterUrl.GetAfterUrl(listOfCrypto, listOfFiat);

            var response = await _client.GetAsync(PublicEndpoints.TickersForAllPairsByMarkets + afterUrl);

            return ResponseConverter<TickersForPairsResponse>.ConvertResponse(response);
        }
    }
}
