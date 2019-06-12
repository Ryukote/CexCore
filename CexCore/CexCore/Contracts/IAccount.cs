using CexCore.Models.Request;
using CexCore.Models.Response;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CexCore.Contracts
{
    /// <summary>
    /// Account endpoints contract
    /// </summary>
    public interface IAccount
    {
        Task<Tuple<HttpStatusCode, AccountBalanceResponse>> GetAccountBalance(AccountBalanceRequest balance);
    }
}
