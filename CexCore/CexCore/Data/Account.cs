using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CexCore.Common;
using CexCore.Contracts;
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

        public async Task<Tuple<HttpStatusCode, AccountBalanceResponse>> GetAccountBalance(AccountBalanceRequest balance)
        {
            var json = JsonConvert.SerializeObject(balance);

            using(HttpContent content = new StringContent(json))
            {
                var response = await _client.PostAsync(AccountEndpoints.AccountBalance, content);
                return ResponseConverter.ConvertBalanceResponse(response);
            }
        }
    }
}
