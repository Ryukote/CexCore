# .NET Core Wrapper for *[CEX.IO](https://cex.io/)*

CexCore is a first (at least on NuGet) .NET Core version of CEX.IO that covers all methods CEX.IO is providing.

CexCore was originally forked Github project from <a href="https://github.com/fasetto">fasetto</a> which was then ported to .NET Core. I have maintained it until CexCore hit version 2.0.0. In that version I have build CexCore from scratch which means I have moved away from original forked code.

Older code that was forked and maintained is now under <a href="https://github.com/Ryukote/CexCoreOld">repository</a> with changed name, so CexCore repository is now reserved for version 2.0.0 and above.

# CEX.IO account

To work with this API library you need to have **valid** and **verified** cex.io account.

For start, under your account select **Profile**

<img src="https://i.imgur.com/fuIpxqs.png" alt=""></img>

Under **API** tab, mark all 5 boxes under **PERMISSIONS** and click on **Generate Key**

<img src="https://i.imgur.com/iDwvS1d.png" alt=""></img>

In order to give your developer account full access you need to enable all boxes under **PERMISSIONS**.

When your key is generated, write somewhere your **User ID**, **Key** and **Secret** before you clik on **Activate**. When you click on **Activate** your **Secret** will become hidden and you will need to delete this key and generate new if you forgot to write those 3 things down before you activated your key.

You will need those 3 information if you want to work with CexCore library.

Entire source is available in this repository and you can check that I am not sending your sensitive data anywhere.

# Where to place credentials in your project

Create **appsettings.json** file if you already don't have it in your project. Store your cex.io sensitive information there.

**IMPORTANT!**: Make sure your **appsettings.json** have next setting:

- **Copy to Output Directory**: "Copy always"

Steps to use that **appsettings.json** file:

1. Install NuGet package:

```
install-package Microsoft.Extensions.Configuration.Json
```

2. Call that **appsettings.json** from your code:

    2.1. Use **IConfiguration**:

```csharp
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional:true, reloadOnChange:true)
    .Build();
```

In first parameter of **AddJsonFile** method, make sure you have included relative path to that json file.

2.2. Make sure you pass **IConfiguration** to whatever place you need. Package by itself doesn't include any constructor with **IConfiguration**, because I don't want to force
anyone to use **IConfiguration** (and **appsettings.json**) if they don't want to.

2.3. Get any of needed value from **appsettings.json** by using **IConfiguration**:

```csharp
var value = _configuration.GetSection("cexCredentials")
    .GetSection("userId")
    .Value;
```

**IMPORTANT**: I have used code above with example string values. Instead of "cexCredentials" you can name your JSON object whatever you like
and same goes with value "userId" (key in JSON object).

You will pass those _configuration values in constructor of any object that requires your credentials.

# Exceptions

CexCore provides several exceptions in the package:

1. **UserIdNotProvidedException** -> You will see this exception if you don't provide user id.
2. **ApiKeyNotProvidedException** -> You will see this exception if you don't provide api key.
3. **ApiSecretNotProvidedException** -> You will see this exception if you don't provide api secret.
4. **CexCollectionException** -> You will see this exception if your collection is empty or null.
5. **CexNullException** -> You will see this exception if response contains unwanted null in some property.

# Issues

If you find any issues regarding code or documentation, please open a new issue on [CexCore issues](https://github.com/Ryukote/CexCore/issues)

If you are openning issue for documentation, please include in title "[Documentation]" prefix.

# Public methods

cex.io provides public API that doesn't require your credentials.
**CexCore** package covers them under **CexCore.Data** namespace under **Public** class. In this part of documentation, you will find how to use methods under that class. Note that every return type under both **Public** and **Account** class is **Tuple** with first parameter being **HttpStatusCode** and second parameter being appropriate object representing data from the response.

## Currency limits

```csharp
var currencyLimits = await new Public().GetCurrencyLimitsAsync();
```

Return type of this method is **Tuple<HttpStatusCode, CurrencyLimitsResponse>**

## Ticker

```csharp
using static CexCore.Common.Symbols;
```

```csharp
var ticker = await new CexCore.Data.Public().GetTickerAsync(CryptoCurrency.BTC, Fiat.USD);
```

Return type of this method is **Tuple<HttpStatusCode, TickerResponse>**

## Ticker for all pairs by market

```csharp
using static CexCore.Common.Symbols;
```

```csharp
List<CryptoCurrency> listOfSymbols = new List<CryptoCurrency>();
List<Fiat> listOfFiat = new List<Fiat>();

listOfSymbols.Add(Symbols.CryptoCurrency.BTC);

listOfFiat.Add(Symbols.Fiat.EUR);

var response = await new Public().GetTickersForPairsByMarketAsync(listOfSymbols, listOfFiat);
```

Return type of this method is **Tuple<HttpStatusCode, TickerForPairsResponse>**

## Last price

```csharp
using static CexCore.Common.Symbols;
```

```csharp
var lastPrice = await new Public().GetLastPriceAsync(CryptoCurrency.BTC.ToString(), Fiat.EUR.ToString());
```

Return type of this method is **Tuple<HttpStatusCode, LastPriceResponse>**

## Last prices for given markets

```csharp
using static CexCore.Common.Symbols;
```

```csharp
List<CryptoCurrency> listOfSymbols = new List<CryptoCurrency>();
List<Fiat> listOfFiat = new List<Fiat>();

listOfSymbols.Add(CryptoCurrency.BTC);

listOfFiat.Add(Fiat.EUR);

var tickerByMarket = await new Public().GetTickersForPairsByMarketAsync(listOfSymbols, listOfFiat);
```

Return type of this method is **Tuple<HttpStatusCode, TickersForPairsResponse>**

## Convert

```csharp
using static CexCore.Common.Symbols;
```

```csharp
var converter = new Converter()
{
    Amount = "1"
};

var convertedAmount = await new Public().GetConvertedAmount(
CryptoCurrency.BTG.ToString(), CryptoCurrency.BTC.ToString(), converter);
```

Return type of this method is **Tuple<HttpStatusCode, Converter>**

## Order book

```csharp
using static CexCore.Common.Symbols;
```

```csharp
var orderBook = new OrderBookRequest()
{
    Symbol1 = CryptoCurrency.BTC.ToString(),
    Symbol2 = Fiat.USD.ToString(),
    Depth = 1
};

var orderBook = await new CexCore.Data.Public().GetOrderBook(orderBook);
```

Return type of this method is **Tuple<HttpStatusCode, OrderBookResponse>**

## Trade history

```csharp
using static CexCore.Common.Symbols;
```

```csharp
var tradeHistory = new TradeHistoryRequest()
{
    Symbol1 = "BTC",
    Symbol2 = "USD",
    Since = 1000
};

var trade = await new Public().GetTradeHistory(tradeHistory);
```

Return type of this method is **Tuple<HttpStatusCode, TradeHistoryResponse>**

# Private/Account methods

cex.io provides private API that require your credentials.
**CexCore** package covers them under **CexCore.Data** namespace under **Account** class. In this part of documentation, you will find how to use methods under that class. Note that every return type under both **Public** and **Account** class is **Tuple** with first parameter being **HttpStatusCode** and second parameter being appropriate object representing data from the response.

## Account balance

```csharp
var accountBalance = new AccountBalanceRequest(userId, apiKey, apiSecret);

var account = new Account();

var balance = await account.GetAccountBalanceAsync(accountBalance);
```

Return type of this method is **Tuple<HttpStatusCode, AccountBalanceResponse>**

## Open orders

```csharp
var baseRequest = new BaseRequest(userId, apiKey, apiSecret);

var openOrders = await new Account().GetOpenOrdersAsync(baseRequest);
```

Return type of this method is **Tuple<HttpStatusCode, OpenOrdersResponse>**

## Open orders by pair

```csharp
var baseRequest = new BaseRequest(userId, apiKey, apiSecret);

var openOrdersByPair = await new Account().GetOpenOrdersByPairAşync("BTC", "USD", baseRequest);
```

Return type of this method is **Tuple<HttpStatusCode, OpenOrdersResponse>**

## Active order status

```csharp
var activeOrderStatus = new ActiveOrderStatusRequest(userId, apiKey, apiSecret);

List<string> list = new List<string>();
list.Add("8550492");
list.Add("8550495");

activeOrderStatus.OrdersList = list.ToArray();

var activeOrders = await new Account().GetActiveOrderStatusAşync(activeOrderStatus);
```

Return type of this method is **Tuple<HttpStatusCode, ActiveOrderStatusResponse>**

## Cancel order

```csharp
var cancelOrderRequest = new CancelOrderRequest(userId, apiKey, apiSecret);

cancelOrderRequest.Id = 12379128;

var cancelOrder = await new Account().CancelOrderAşync(cancelOrderRequest);
```

Return type of this method is **Tuple<HttpStatusCode, CancelOrderResponse>**

## Cancel all orders

```csharp
var baseRequest = new BaseRequest(userId, apiKey, apiSecret);

var cancelAllOrders = await new Account().CancelOrdersForGivenPairAşync("BTC", "USD", baseRequest);
```

Return type of this method is **Tuple<HttpStatusCode, CancelAllOrdersForGivenPairResponse>**

## Place order

Limit order:

```csharp
var placeOrderRequest = new PlaceOrderRequest(userId, apiKey, apiSecret)
{
    Type = "buy",
    Amount = 12,
    Price = 1155.67m
};

var placeOrder = await new Account().PlaceOrderAşync("BTC", "USD", placeOrderRequest);
```

Market order:

```csharp
var placeOrderRequest = new PlaceOrderRequest(userId, apiKey, apiSecret)
{
    Type = "buy",
    Amount = 12,
    OrderType = "market"
};

var placeOrder = await new Account().PlaceOrderAşync("BTC", "USD", placeOrderRequest);
```

Return type of this method is **Tuple<HttpStatusCode, PlaceOrderResponse>**

## Cryptocurreny address

```csharp
var cryptoAddressRequest = new CryptoAddressRequest(userId, apiKey, apiSecret)
{
    Currency = "BTC"
};

var address = await new Account().GetCryptoAddressAşync(cryptoAddressRequest);
```

Return type of this method is **Tuple<HttpStatusCode, CryptoAddressResponse>**

## My fee

```csharp
var request = new BaseRequest(userId, apiKey, apiSecret);

var fee = await new CexCore.Data.Account().GetMyFeeAşync(request);
```

Return type of this method is **Tuple<HttpStatusCode, GetMyFeeResponse>**

## Cancel replace order

```csharp
var cancelReplaceOrderRequest = new CancelReplaceOrderRequest(userId, apiKey, apiSecret)
{
    Type = "buy"
};

var cancel = await new Account().CancelReplaceOrderAsync("BTC", "USD", cancelReplaceOrderRequest);
```

Return type of this method is **Tuple<HttpStatusCode, CancelReplaceOrderResponse>**

## Open position

```csharp
var request = new OpenPositionOrderRequest(userId, apiKey, apiSecret)
{
    Symbol = "BTC",
    MSymbol = "BTC"
};

var openPosition = await new Account().OpenPositionAsync("BTC", "USD", request);
```

Return type of this method is **Tuple<HttpStatusCode, OpenPositionOrderResponse>**

## Close position

```csharp
var request = new ClosePositionRequest(userId, apiKey, apiSecret)
{
    Id = 1290312
};

var closePosition = await new Account().ClosePositionAsync("BTC", "USD", request);
```

Return type of this method is **Tuple<HttpStatusCode, ClosePositionResponse>**
