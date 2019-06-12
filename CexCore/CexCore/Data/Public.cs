using CexCore.Common;
using CexCore.Contracts;
using CexCore.Exceptions;
using CexCore.Models.Response;
using CexCore.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
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

        public async Task<Tuple<HttpStatusCode, CurrencyLimitsResponse>> GetCurrencyLimitsAsync()
        {
            var response = await _client.GetAsync(PublicEndpoints.CurrencyLimits);
            return ResponseConverter<CurrencyLimitsResponse>.ConvertResponse(response);
        }

        public async Task<Tuple<HttpStatusCode, TickerResponse>> GetTickerAsync(CryptoCurrency cryptoCurrency, Fiat fiat)
        {
            var response = await _client.GetAsync(PublicEndpoints.Ticker(cryptoCurrency, fiat));
            return ResponseConverter<TickerResponse>.ConvertResponse(response);
        }

        public async Task<Tuple<HttpStatusCode, TickersForPairsResponse>> GetTickersForPairsByMarketAsync
            (ICollection<Symbols.CryptoCurrency> listOfCrypto, ICollection<Symbols.Fiat> listOfFiat)
        {
            string afterUrl = string.Empty;

            if((listOfCrypto.Count.Equals(0) && listOfFiat.Count.Equals(0))
                || (listOfCrypto == null && listOfFiat == null))
            {
                throw new CexCollectionException(CexExceptionMessages.CexCollectionException);
            }

            if(listOfCrypto != null && listOfCrypto.Count > 0)
            {
                foreach (var symbol in listOfCrypto)
                {
                    afterUrl = "/" + symbol.ToString();
                }
            }

            if (listOfFiat != null && listOfFiat.Count > 0)
            {
                foreach (var symbol in listOfFiat)
                {
                    afterUrl = "/" + symbol.ToString();
                }
            }

            var response = await _client.GetAsync(PublicEndpoints.TickersForAllPairsByMarkets + afterUrl);

            return ResponseConverter<TickersForPairsResponse>.ConvertResponse(response);
        }
    }
}
