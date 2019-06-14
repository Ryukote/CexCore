using CexCore.Contracts;

namespace CexCore.Models.Response
{
    public class OpenOrdersResponse : IResponse
    {
        public Common.OpenOrders[] OpenOrders { get; set; }
    }
}
