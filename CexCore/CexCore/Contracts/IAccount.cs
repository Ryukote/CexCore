using CexCore.Models.Request;
using CexCore.Models.Response;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CexCore.Contracts
{
    /// <summary>
    /// Account endpoints contract.
    /// </summary>
    internal interface IAccount
    {
        Task<Tuple<HttpStatusCode, AccountBalanceResponse>> GetAccountBalanceAsync(AccountBalanceRequest balance);

        Task<Tuple<HttpStatusCode, OpenOrdersResponse>> GetOpenOrdersAsync(BaseRequest request);

        Task<Tuple<HttpStatusCode, OpenOrdersResponse>> GetOpenOrdersByPairAşync(string symbol1, string symbol2, BaseRequest request);

        Task<Tuple<HttpStatusCode, ActiveOrderStatusResponse>> GetActiveOrderStatusAşync(ActiveOrderStatusRequest request);

        Task<Tuple<HttpStatusCode, CancelOrderResponse>> CancelOrderAşync(CancelOrderRequest request);

        Task<Tuple<HttpStatusCode, CancelAllOrdersForGivenPairResponse>> CancelOrdersForGivenPairAşync(string symbol1, string symbol2, BaseRequest request);

        Task<Tuple<HttpStatusCode, PlaceOrderResponse>> PlaceOrderAşync(string symbol1, string symbol2, PlaceOrderRequest request);

        Task<Tuple<HttpStatusCode, CryptoAddressResponse>> GetCryptoAddressAşync(CryptoAddressRequest addressRequest);

        Task<Tuple<HttpStatusCode, GetMyFeeResponse>> GetMyFeeAşync(BaseRequest request);

        Task<Tuple<HttpStatusCode, CancelReplaceOrderResponse>> CancelReplaceOrderAsync(string symbol1, string symbol2, CancelReplaceOrderRequest request);

        Task<Tuple<HttpStatusCode, OpenPositionOrderResponse>> OpenPositionAsync(string symbol1, string symbol2, OpenPositionOrderRequest request);

        Task<Tuple<HttpStatusCode, ClosePositionResponse>> ClosePositionAsync(string symbol1, string symbol2, ClosePositionRequest request);
    }
}
