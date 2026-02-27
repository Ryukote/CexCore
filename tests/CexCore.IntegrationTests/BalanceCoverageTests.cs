using CexCore.MarketEntities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CexCore.IntegrationTests;

public class BalanceCoverageTests
{
    [Fact]
    public void TryGetSymbolBalance_Should_Read_Known_And_Dynamic_Symbols()
    {
        var json = """
        {
          "timestamp": "1700000000",
          "BTC": { "available": 1.0, "bonus": 0.0, "orders": 0.1 },
          "USDT": { "available": 5.0, "bonus": 0.0, "orders": 0.2 }
        }
        """;

        var balance = JsonConvert.DeserializeObject<Balance>(json);

        Assert.NotNull(balance);
        Assert.True(balance.TryGetSymbolBalance(Symbols.BTC, out var btc));
        Assert.NotNull(btc);
        Assert.Equal(1.0m, btc.Available);

        Assert.True(balance.TryGetSymbolBalance(Symbols.USDT, out var usdt));
        Assert.NotNull(usdt);
        Assert.Equal(5.0m, usdt.Available);
    }

    [Fact]
    public void TryGetSymbolBalance_Should_Support_All_Defined_Symbols()
    {
        var root = new JObject
        {
            ["timestamp"] = "1700000000"
        };

        foreach (var symbol in Enum.GetValues(typeof(Symbols)))
        {
            var symbolName = symbol.ToString() ?? string.Empty;

            root[ToApiSymbolName(symbolName)] = new JObject
            {
                ["available"] = 1.0m,
                ["bonus"] = 0.0m,
                ["orders"] = 0.0m
            };
        }

        var balance = JsonConvert.DeserializeObject<Balance>(root.ToString());

        Assert.NotNull(balance);

        foreach (Symbols symbol in Enum.GetValues(typeof(Symbols)))
        {
            Assert.True(
                balance.TryGetSymbolBalance(symbol, out var symbolBalance),
                $"Symbol '{symbol}' was not resolved from Balance model.");
            Assert.NotNull(symbolBalance);
        }
    }

    [Fact]
    public void TryGetSymbolBalance_Should_Resolve_AliasSymbol_From_ApiTickerName()
    {
        var json = """
        {
          "timestamp": "1700000000",
          "1INCH": { "available": 7.0, "bonus": 0.0, "orders": 0.0 }
        }
        """;

        var balance = JsonConvert.DeserializeObject<Balance>(json);

        Assert.NotNull(balance);
        Assert.True(balance.TryGetSymbolBalance(Symbols.N1INCH, out var symbolBalance));
        Assert.NotNull(symbolBalance);
        Assert.Equal(7.0m, symbolBalance.Available);
    }

    private static string ToApiSymbolName(string symbolName)
    {
        return symbolName switch
        {
            "N0G" => "0G",
            "N1000SATS" => "1000SATS",
            "N1INCH" => "1INCH",
            "N2Z" => "2Z",
            "N67" => "67",
            _ => symbolName
        };
    }
}
