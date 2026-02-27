using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Xunit;

namespace CexCore.IntegrationTests;

public class EnumCoverageFromJsonTests
{
    [Fact]
    public void Symbols_And_SymbolPairs_Should_Cover_All_Valid_BaseQuote_Combinations()
    {
        var repoRoot = FindRepoRoot();
        var symbolsFile = Path.Combine(repoRoot, "CexCore", "MarketEntities", "Symbols.cs");
        var valuteFile = Path.Combine(repoRoot, "valute.json");

        var symbolsSource = File.ReadAllText(symbolsFile);
        var valuteSource = File.ReadAllText(valuteFile);

        var symbols = ParseEnumItems(symbolsSource, "Symbols");
        var pairs = ParseEnumItems(symbolsSource, "SymbolPairs");
        var entries = JsonSerializer.Deserialize<List<ValutaEntry>>(valuteSource) ?? [];

        static bool IsValidEnumToken(string value) =>
            Regex.IsMatch(value, "^[A-Za-z][A-Za-z0-9_]*$");

        var missingSymbols = new List<string>();
        var missingPairs = new List<string>();

        foreach (var entry in entries)
        {
            var baseSymbol = (entry.Base ?? string.Empty).Trim().ToUpperInvariant();
            var quoteSymbol = (entry.Quote ?? string.Empty).Trim().ToUpperInvariant();

            if (string.IsNullOrWhiteSpace(baseSymbol) || string.IsNullOrWhiteSpace(quoteSymbol))
                continue;

            if (IsValidEnumToken(baseSymbol) && !symbols.Contains(baseSymbol))
                missingSymbols.Add(baseSymbol);

            if (IsValidEnumToken(quoteSymbol) && !symbols.Contains(quoteSymbol))
                missingSymbols.Add(quoteSymbol);

            if (IsValidEnumToken(baseSymbol) && IsValidEnumToken(quoteSymbol))
            {
                var pair = $"{baseSymbol}_{quoteSymbol}";
                if (!pairs.Contains(pair))
                    missingPairs.Add(pair);
            }
        }

        Assert.True(missingSymbols.Count == 0, $"Missing symbols: {string.Join(", ", missingSymbols.Distinct().OrderBy(x => x))}");
        Assert.True(missingPairs.Count == 0, $"Missing pairs: {string.Join(", ", missingPairs.Distinct().OrderBy(x => x))}");
    }

    private static HashSet<string> ParseEnumItems(string source, string enumName)
    {
        var match = Regex.Match(source, $"public enum {enumName}\\s*\\{{(?<body>[\\s\\S]*?)\\}}");
        if (!match.Success)
            throw new InvalidOperationException($"Enum '{enumName}' not found.");

        var body = match.Groups["body"].Value;
        var lines = body.Split('\n');

        var items = new HashSet<string>(StringComparer.Ordinal);

        foreach (var line in lines)
        {
            var normalized = line.Split("//")[0].Trim().TrimEnd(',');
            if (!string.IsNullOrWhiteSpace(normalized))
                items.Add(normalized);
        }

        return items;
    }

    private static string FindRepoRoot()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);

        while (directory != null)
        {
            var candidate = Path.Combine(directory.FullName, "CexCore", "MarketEntities", "Symbols.cs");
            if (File.Exists(candidate))
                return directory.FullName;

            directory = directory.Parent;
        }

        throw new DirectoryNotFoundException("Could not locate repository root.");
    }

    private sealed class ValutaEntry
    {
        [JsonPropertyName("base")]
        public string? Base { get; init; }
        [JsonPropertyName("quote")]
        public string? Quote { get; init; }
    }
}
