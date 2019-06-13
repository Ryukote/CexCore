namespace CexCore.Models.Request
{
    public class TradeHistoryRequest
    {
        /// <summary>
        /// The first currency code.
        /// </summary>
        public string Symbol1 { get; set; }

        /// <summary>
        /// The second currency code.
        /// </summary>
        public string Symbol2 { get; set; }

        /// <summary>
        /// return trades with tid >= since (optional parameter, 1000 or all existing (if less than 1000), elements are returned if omitted).
        /// </summary>
        public int Since { get; set; }
    }
}
