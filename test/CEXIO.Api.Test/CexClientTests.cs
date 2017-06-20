using CEXIO.Api.Common;
using CEXIO.Api.Exceptions;
using CEXIO.Api.MarketEntities;
using NUnit.Framework;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CEXIO.Api.Test
{
    [TestFixture]
    public class CexClientTests
    {
        private ApiCredentials credentials = null;
        private CexClient client = null;

        [SetUp]
        public void Init()
        {
            credentials = new ApiCredentials(
                "userId",
                "apiKey",
                "apiSecret"
                );
            client = new CexClient();
        }

        [Test]
        public async Task OpenPositionTest()
        {
            // Arrange 
            client.Credentials = credentials;

            var lastPrice = await client.GetLastPriceAsync(SymbolPairs.BTC_USD);

            var position = new Position()
            {
                Pair = SymbolPairs.BTC_USD,
                Amount = 0.05m,
                Symbol = Symbols.BTC,
                Leverage = 2,
                Type = PositionType.Long,
                EstimatedOpenPrice = lastPrice,
                StopLossPrice = lastPrice - 40m
            };

            // Act
            var positionId = await client.Account.OpenPosition(position);

            // Assert
            Assert.IsTrue(positionId != -1);
        }

        [Test]
        public async Task ClosePositionTest()
        {
            // Arrange
            client.Credentials = credentials;

            // Act
            var isSuccess = await client.Account.ClosePosition(SymbolPairs.BTC_USD, 148418);

            // Assert
            Assert.IsTrue(isSuccess);
        }

        [Test]
        public async Task PlaceLimitOrderTest()
        {
            // Arrange
            client.Credentials = credentials;

            var order = new Order(SymbolPairs.BTC_USD, 2600m, 0.01m, OrderType.Buy);

            // Act
            var result = await client.Account.PlaceLimitOrder(order);

            // Assert
            Assert.AreEqual(order.Price, result.Price);
            Assert.AreEqual(order.Amount, result.Amount);
        }

        [Test]
        public async Task GetOpenPositionsTest()
        {
            client.Credentials = credentials;

            var positions = await client.Account.GetOpenPositonsAsync(SymbolPairs.ETH_USD);

            Assert.NotNull(positions);
        }

        [Test]
        public async Task GetAddressTest()
        {
            // Arrange
            client.Credentials = credentials;

            // Act
            var addrr = await client.Account.GetAddressAsync(Symbols.BTC);

            Debug.WriteLine($"Your BTC address is: {addrr}");

            // Assert
            Assert.IsTrue(addrr.Length > 0);
        }
        
        [Test]
        public async Task GetOpenOrdersTest()
        {
            // Arrange
            client.Credentials = credentials;

            // Act
            var orders = await client.Account.GetOpenOrdersAsync(SymbolPairs.ETH_USD);

            Debug.WriteLine("Open orders");

            foreach (var order in orders)
                Debug.WriteLine($"Id: {order.Id}");

            // Assert
            Assert.IsTrue(orders.Count() > 0);
        }

        [Test]
        public async Task OrderBookTest()
        {
            // Arrange
            var orderbook = await client.GetOrderBookAsync(SymbolPairs.BTC_USD, 7);

            // Assert
            Assert.AreEqual(7, orderbook.Asks.Count());
        }

        [Test]
        public void CancelOrderUsingId()
        {
            client.Credentials = credentials;

            Assert.That(async () => await client.Account.CancelOrder(3913505339L), Throws.Nothing);
        }

        [Test]
        public void CancelOrderTest()
        {
            client.Credentials = credentials;
            Assert.That(async () => await client.Account.CancelOrder(SymbolPairs.BTC_USD), Throws.Nothing);
        }

        [Test]
        public async Task ConvertTest()
        {
            decimal bitcoin = 1m;
            decimal usdAmount = await client.Convert(SymbolPairs.BTC_USD, bitcoin);

            Assert.IsTrue(usdAmount > 2700m);
        }

        [Test]
        public async Task TickerTest()
        {
            var ticker = await client.GetTickerAsync(SymbolPairs.ETH_USD);

            Debug.WriteLine("Ticker (EHT-USD)");
            Debug.WriteLine($"Ask: {ticker.Ask}");

            Assert.IsTrue(ticker.Ask > 0.0m);
        }

        [Test]
        public async Task GetLastPriceTest()
        {
            decimal price = await client.GetLastPriceAsync(SymbolPairs.BTC_USD);

            Debug.WriteLine("BTC-USD");
            Debug.WriteLine($"Price: {price}");

            Assert.IsTrue(price > 0.0m);
        }

        [Test]
        public void ThrowsInvalidKeyExceptionWhenApiKeyIsInvalid()
        {
            // Arrange
            ApiCredentials credentials = new ApiCredentials(
                "userId",
                "apiKey",
                "apiSecret"
                );

            client.Credentials = credentials;

            // Assert
            Assert.ThrowsAsync<InvalidApiKeyException>(async () =>
            {
                await client.Account.GetBalanceAsync();
            });
        }

        [Test]
        public async Task BalanceTest()
        {
            // Arrange
            client.Credentials = credentials;

            // Act
            Balance balance = await client.Account.GetBalanceAsync();

            // Assert
            Assert.IsTrue(balance.USD.Available > 0.0m);
        }

    }
}