using System.Collections.Generic;

namespace CexCore.Helpers
{
    internal static class SymbolAliasMapper
    {
        private static readonly Dictionary<string, string> EnumToApiSymbol =
            new Dictionary<string, string>(System.StringComparer.Ordinal)
            {
                { "N0G", "0G" },
                { "N1000SATS", "1000SATS" },
                { "N1INCH", "1INCH" },
                { "N2Z", "2Z" },
                { "N67", "67" }
            };

        internal static string ToApiSymbol(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
                return symbol;

            return EnumToApiSymbol.TryGetValue(symbol, out var mapped)
                ? mapped
                : symbol;
        }
    }
}
