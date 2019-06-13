using CexCore.Contracts;

namespace CexCore.Models.Response
{
    public class OpenOrdersResponse : IResponse
    {
        public OpenOrders[] OpenOrders { get; set; }
    }
}
