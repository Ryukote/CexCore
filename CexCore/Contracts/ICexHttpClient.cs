using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CexCore.Contracts
{
    /// <summary>
    /// Interface for CexHttpClient
    /// </summary>
    public interface ICexHttpClient
    {
        Task<Tuple<HttpStatusCode, string>> CexGetAsync(string url);
        Task<Tuple<HttpStatusCode, string>> CexPostAsync(string url, HttpContent httpContent);
    }
}
