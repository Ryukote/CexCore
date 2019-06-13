using CexCore.Common;
using CexCore.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CexCore.Utilities
{
    internal static class AfterUrl
    {
        internal static string GetAfterUrl(ICollection<Symbols.CryptoCurrency> listOfCrypto, ICollection<Symbols.Fiat> listOfFiat)
        {
            string afterUrl = string.Empty;

            if ((listOfCrypto.Count.Equals(0) && listOfFiat.Count.Equals(0))
                || (listOfCrypto == null && listOfFiat == null))
            {
                throw new CexCollectionException(CexExceptionMessages.CexCollectionException);
            }

            if (listOfCrypto != null && listOfCrypto.Count > 0)
            {
                foreach (var symbol in listOfCrypto)
                {
                    afterUrl = "/" + symbol.ToString();
                }
            }

            if (listOfFiat != null && listOfFiat.Count > 0)
            {
                foreach (var symbol in listOfFiat)
                {
                    afterUrl += "/" + symbol.ToString();
                }
            }

            return afterUrl;
        }

        internal static string GetAfterUrlGeneral(ICollection<string> list)
        {
            string afterUrl = string.Empty;

            if (list.Count.Equals(0) || list == null)
            {
                throw new CexCollectionException(CexExceptionMessages.CexGeneralCollectionException);
            }

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    afterUrl += "/" + item.ToString();
                }
            }

            return afterUrl;
        }
    }
}
