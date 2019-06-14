namespace CexCore.Models.Request
{
    public class ClosePositionRequest : CancelOrderRequest
    {
        public ClosePositionRequest(string userId, string apiKey, string apiSecret) : base(userId, apiKey, apiSecret)
        {
        }
    }
}
