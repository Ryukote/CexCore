using System.Net;
using System.Text.Json;
using Xunit;

namespace CexCore.IntegrationTests;

public class CexPublicApiSmokeTests
{
    private static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri("https://cex.io/api/")
    };

    private static bool RunLiveTests =>
        string.Equals(
            Environment.GetEnvironmentVariable("RUN_LIVE_CEX_TESTS"),
            "true",
            StringComparison.OrdinalIgnoreCase);

    [Theory]
    [InlineData("BTC", "USD")]
    [InlineData("ETH", "USD")]
    [InlineData("XRP", "USD")]
    public async Task Ticker_Endpoint_Returns_ExpectedShape(string symbol1, string symbol2)
    {
        if (!RunLiveTests)
            return;

        using var response = await HttpClient.GetAsync($"ticker/{symbol1}/{symbol2}");
        var body = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        using var json = JsonDocument.Parse(body);
        Assert.True(json.RootElement.TryGetProperty("last", out _), $"Missing 'last'. Body: {body}");
        Assert.True(json.RootElement.TryGetProperty("bid", out _), $"Missing 'bid'. Body: {body}");
        Assert.True(json.RootElement.TryGetProperty("ask", out _), $"Missing 'ask'. Body: {body}");
    }

    [Theory]
    [InlineData("BTC", "USD")]
    [InlineData("ETH", "USD")]
    public async Task LastPrice_Endpoint_Returns_LPrice(string symbol1, string symbol2)
    {
        if (!RunLiveTests)
            return;

        using var response = await HttpClient.GetAsync($"last_price/{symbol1}/{symbol2}");
        var body = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        using var json = JsonDocument.Parse(body);
        Assert.True(json.RootElement.TryGetProperty("lprice", out _), $"Missing 'lprice'. Body: {body}");
    }

    [Fact]
    public async Task OrderBook_Endpoint_Returns_Bids_And_Asks()
    {
        if (!RunLiveTests)
            return;

        using var response = await HttpClient.GetAsync("order_book/BTC/USD");
        var body = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        using var json = JsonDocument.Parse(body);
        Assert.True(json.RootElement.TryGetProperty("bids", out _), $"Missing 'bids'. Body: {body}");
        Assert.True(json.RootElement.TryGetProperty("asks", out _), $"Missing 'asks'. Body: {body}");
    }
}
