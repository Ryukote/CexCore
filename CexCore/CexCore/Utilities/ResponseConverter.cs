using CexCore.Models.Response;
using Newtonsoft.Json;
using System;
using System.Net;

namespace CexCore.Utilities
{
    internal static class ResponseConverter
    {
        internal static Tuple<HttpStatusCode, AccountBalanceResponse> ConvertBalanceResponse(Tuple<HttpStatusCode, string> response)
        {
            AccountBalanceResponse account = JsonConvert.DeserializeObject<AccountBalanceResponse>(response.Item2);

            return new Tuple<HttpStatusCode, AccountBalanceResponse>(response.Item1, account);
        }
    }
}
