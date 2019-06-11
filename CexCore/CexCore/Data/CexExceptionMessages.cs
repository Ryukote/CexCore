namespace CexCore.Data
{
    public static class CexExceptionMessages
    {
        #region Http client exception messages

            public static string HttpGetRequestException = "Something is wrong with a GET request." +
                " Check if CEX.IO API is live on: https://status.cex.io" +
                " or check if your url is valid.";

            public static string HttpPostRequestException = "Something is wrong with a POST request." +
                " Check if CEX.IO API is live on: https://status.cex.io" +
                " or check if your url and body is valid.";

        #endregion
    }
}
