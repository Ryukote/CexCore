namespace CexCore.Models.Request
{
    public class AccountBalanceRequest : BaseRequest
    {
        public AccountBalanceRequest(string userId, string apiKey, string apiSecret)
            : base(userId, apiKey, apiSecret)
        {
        }
    }
}
