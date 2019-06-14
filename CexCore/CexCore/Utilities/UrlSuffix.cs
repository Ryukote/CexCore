using CexCore.Common;
using CexCore.Exceptions;
using System.Collections.Generic;

namespace CexCore.Utilities
{
    internal static class UrlSuffix
    {
        internal static string GetUrlSuffix(ICollection<Symbols.CryptoCurrency> listOfCrypto, ICollection<Symbols.Fiat> listOfFiat)
        {
            string urlSuffix = string.Empty;

            if ((listOfCrypto.Count.Equals(0) && listOfFiat.Count.Equals(0))
                || (listOfCrypto == null && listOfFiat == null))
            {
                throw new CexCollectionException(CexExceptionMessages.CexCollectionException);
            }

            if (listOfCrypto != null && listOfCrypto.Count > 0)
            {
                foreach (var symbol in listOfCrypto)
                {
                    urlSuffix = "/" + symbol.ToString();
                }
            }

            if (listOfFiat != null && listOfFiat.Count > 0)
            {
                foreach (var symbol in listOfFiat)
                {
                    urlSuffix += "/" + symbol.ToString();
                }
            }

            return urlSuffix;
        }

        internal static string GetGeneralUrlSuffix(ICollection<string> list)
        {
            string urlSuffix = string.Empty;

            if (list.Count.Equals(0) || list == null)
            {
                throw new CexCollectionException(CexExceptionMessages.CexGeneralCollectionException);
            }

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    urlSuffix += "/" + item.ToString();
                }
            }

            return urlSuffix;
        }
    }
}
