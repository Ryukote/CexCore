using CexCore.Contracts;

namespace CexCore.Models.Response
{
    public class TradeHistoryResponse : IResponse
    {
        public TradeHistory[] TradeHistory { get; set; }
    }
}
