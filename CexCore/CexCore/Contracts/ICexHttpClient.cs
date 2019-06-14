using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CexCore.Contracts
{
    /// <summary>
    /// CEX.IO http client contract.
    /// </summary>
    internal interface ICexHttpClient
    {
        Task<Tuple<HttpStatusCode, string>> GetAsync(string url);

        Task<Tuple<HttpStatusCode, string>> PostAsync(string url, HttpContent httpContent);
    }
}
