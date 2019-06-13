using Newtonsoft.Json;

namespace CexCore.Models.Request
{
    public class OrderBookRequest
    {
        public string Symbol1 { get; set; }

        public string Symbol2 { get; set; }

        public int Depth { get; set; }
    }
}
