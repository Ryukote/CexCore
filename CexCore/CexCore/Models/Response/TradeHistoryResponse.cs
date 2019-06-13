using CexCore.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CexCore.Models.Response
{
    public class TradeHistoryResponse : IResponse
    {
        public static TradeHistory[] TradeHistoryList(string json) => JsonConvert.DeserializeObject<TradeHistory[]>(json);

        public TradeHistory[] TradeHistory { get; set; }
    }
}
