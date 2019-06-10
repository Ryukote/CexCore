using System.Text;

namespace CexCore.Data
{
    public static class CexConstants
    {
        #region Account constants
        public const string CancelOrderUrl = "https://cex.io/api/cancel_order/";
        #endregion

        #region Exception messages
        public const string GeneralException = "Something went wrong." + 
            " If you think this exception is not caused by you, open" + 
            " a new issue on https://github.com/Ryukote/CexCore" + 
            " with given exception message and stack trace and describe" +
            " step by step how to get to the exception.";
        public const string HttpPostRequestException = "Something is wrong with a POST request." +
            " Check if CEX.IO API is live on: https://status.cex.io" +
            " or check if your url and body is valid.";
        #endregion
    }
}
