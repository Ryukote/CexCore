﻿namespace CexCore.Common
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

        #region Custom exceptions
        public static string UserIdNotProvidedException = "User id is not provided.";

        public static string ApiKeyNotProvidedException = "API key is not provided.";

        public static string ApiSecretNotProvidedException = "API secret is not provided.";

        public static string CexCollectionException = "You provided either (one or multiple) empty collection(s)" +
            " or (one or multiple) null collection(s).";

        public static string CexGeneralCollectionException = "You provided either empty collection" +
            " or null collection.";

        public static string CexNullCurrenciesException = "Check currency1 and currency2." +
            "You probably didn't enter valid values or valid pairs.";
        #endregion
    }
}
