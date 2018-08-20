
## .NET Wrapper for *[CEX.IO](https://cex.io/)*

### Getting started
This is completed version of original repository by fasetto.
In this fork, I have filled the gap created by original author with adding all crypto currencies available on CEX.IO and fixed a small bug for placing market order.
## SetUp

```csharp
private ApiCredentials credentials = new ApiCredentials(
                                        "userId",
                                        "apiKey",
                                        "apiSecret"
                                        );

private CexClient client = new CexClient(credentials);

```

.. or you can use for public commands without api credentials like this ;

`private CexClient client = new CexClient();`

## Balance
```csharp
Balance balance    = await client.Account.GetBalanceAsync();
decimal btcBalance = balance.BTC.Available;

```

### Last price
`var lastPrice = await client.GetLastPriceAsync(SymbolPairs.BTC_USD);`

### Place order
```csharp
var order    = new Order(SymbolPairs.BTC_USD, 2400.0m, 0.01m, OrderType.Buy);
Order result = await client.Account.PlaceLimitOrder(order);
```

### Margin trading
```csharp
var lastPrice = await client.GetLastPriceAsync(SymbolPairs.BTC_USD);

var position = new Position()
{
    Pair = SymbolPairs.BTC_USD,
    Amount = 4.7m,
    Symbol = Symbols.BTC,
    Leverage = 3,
    Type = PositionType.Short,
    EstimatedOpenPrice = lastPrice,
    StopLossPrice = lastPrice + 40.0m
};

// returns position id.
var positionId = await client.Account.OpenPosition(position);
```

## Donations 
If you're feeling generous, you can donate </br>
[![Bitcoin Donate Button](https://www.drupal.org/files/project-images/bitcoindonate.png)][btc-addr]

[btc-addr]: <https://blockchain.info/address/322SRqTS3EeKGaVFuo6xsw8e5Xji4QcJR6>
