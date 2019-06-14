using CexCore.Contracts;

namespace CexCore.Models.Response
{
    public class TradeHistoryResponse : IResponse
    {
        public Common.TradeHistory[] TradeHistory { get; set; }
    }
}
