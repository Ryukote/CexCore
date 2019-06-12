using CexCore.Common;
using CexCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using static CexCore.Common.Symbols;

namespace CexCore.Contracts
{
    public interface IPublic
    {
        Task<Tuple<HttpStatusCode, CurrencyLimitsResponse>> GetCurrencyLimitsAsync();

        Task<Tuple<HttpStatusCode, TickerResponse>> GetTickerAsync(CryptoCurrency cryptoCurrency, Fiat fiat);

        Task<Tuple<HttpStatusCode, TickersForPairsResponse>> GetTickersForPairsByMarketAsync
            (ICollection<Symbols.CryptoCurrency> listOfCrypto, ICollection<Symbols.Fiat> listOfFiat);
    }
}
