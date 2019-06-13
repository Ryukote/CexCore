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

        public async Task<Tuple<HttpStatusCode, AccountBalanceResponse>> GetAccountBalanceAsync(AccountBalanceRequest balance)
        {
            var json = JsonConvert.SerializeObject(balance);

            using (HttpContent content = new StringContent(json))
            {
                var response = await _client.PostAsync(AccountEndpoints.AccountBalance, content);
                return ResponseConverter<AccountBalanceResponse>.ConvertResponse(response);
            }
        }

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
    }
}
