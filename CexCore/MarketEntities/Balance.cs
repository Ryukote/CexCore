using CexCore.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CexCore.MarketEntities
{
    public class Balance : EntityBase
    {
        private static readonly Dictionary<string, PropertyInfo> SymbolBalanceProperties =
            typeof(Balance)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(p => p.PropertyType == typeof(SymbolBalance))
                .ToDictionary(p => p.Name.ToUpperInvariant(), p => p, StringComparer.Ordinal);

        [JsonProperty("timestamp")]
        public Timestamp Timestamp { get; private set; }

        [JsonProperty("BTC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BTC { get; private set; }

        [JsonProperty("USD")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance USD { get; private set; }

        [JsonProperty("EUR")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance EUR { get; private set; }

        [JsonProperty("ETH")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ETH { get; private set; }

        [JsonProperty("RUB")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance RUB { get; private set; }

        [JsonProperty("GBP")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GBP { get; private set; }

        [JsonProperty("GHS")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GHS { get; private set; }

        [JsonProperty("BCH")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BCH { get; private set; }

        [JsonProperty("DASH")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance DASH { get; private set; }

        [JsonProperty("XRP")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance XRP { get; private set; }

        [JsonProperty("ZEC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ZEC { get; private set; }

        [JsonProperty("BTG")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BTG { get; private set; }

        [JsonProperty("XLM")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance XLM { get; private set; }

        [JsonProperty("GUSD")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GUSD { get; private set; }

        [JsonProperty("OMG")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance OMG { get; private set; }

        [JsonProperty("MHC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MHC { get; private set; }

        [JsonProperty("USDT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance USDT { get; private set; }

        [JsonProperty("BNB")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BNB { get; private set; }

        [JsonProperty("USDC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance USDC { get; private set; }

        [JsonProperty("SOL")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SOL { get; private set; }

        [JsonProperty("TRX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance TRX { get; private set; }

        [JsonProperty("DOGE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance DOGE { get; private set; }

        [JsonProperty("ADA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ADA { get; private set; }

        [JsonProperty("WBTC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance WBTC { get; private set; }

        [JsonProperty("HYPE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance HYPE { get; private set; }

        [JsonProperty("LINK")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance LINK { get; private set; }

        [JsonProperty("DAI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance DAI { get; private set; }

        [JsonProperty("USD1")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance USD1 { get; private set; }

        [JsonProperty("HBAR")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance HBAR { get; private set; }

        [JsonProperty("LTC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance LTC { get; private set; }

        [JsonProperty("AVAX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance AVAX { get; private set; }

        [JsonProperty("SUI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SUI { get; private set; }

        [JsonProperty("SHIB")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SHIB { get; private set; }

        [JsonProperty("TON")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance TON { get; private set; }

        [JsonProperty("CRO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance CRO { get; private set; }

        [JsonProperty("WLFI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance WLFI { get; private set; }

        [JsonProperty("DOT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance DOT { get; private set; }

        [JsonProperty("PAXG")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PAXG { get; private set; }

        [JsonProperty("UNI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance UNI { get; private set; }

        [JsonProperty("MNT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MNT { get; private set; }

        [JsonProperty("TAO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance TAO { get; private set; }

        [JsonProperty("AAVE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance AAVE { get; private set; }

        [JsonProperty("ASTER")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ASTER { get; private set; }

        [JsonProperty("PI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PI { get; private set; }

        [JsonProperty("PEPE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PEPE { get; private set; }

        [JsonProperty("SKY")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SKY { get; private set; }

        [JsonProperty("NEAR")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance NEAR { get; private set; }

        [JsonProperty("ICP")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ICP { get; private set; }

        [JsonProperty("ETC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ETC { get; private set; }

        [JsonProperty("ONDO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ONDO { get; private set; }

        [JsonProperty("POL")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance POL { get; private set; }

        [JsonProperty("WLD")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance WLD { get; private set; }

        [JsonProperty("JLP")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance JLP { get; private set; }

        [JsonProperty("NIGHT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance NIGHT { get; private set; }

        [JsonProperty("ATOM")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ATOM { get; private set; }

        [JsonProperty("ENA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ENA { get; private set; }

        [JsonProperty("KAS")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance KAS { get; private set; }

        [JsonProperty("FLR")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance FLR { get; private set; }

        [JsonProperty("ALGO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ALGO { get; private set; }

        [JsonProperty("TRUMP")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance TRUMP { get; private set; }

        [JsonProperty("QNT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance QNT { get; private set; }

        [JsonProperty("APT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance APT { get; private set; }

        [JsonProperty("FIL")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance FIL { get; private set; }

        [JsonProperty("RENDER")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance RENDER { get; private set; }

        [JsonProperty("MORPHO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MORPHO { get; private set; }

        [JsonProperty("XDC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance XDC { get; private set; }

        [JsonProperty("PIPPIN")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PIPPIN { get; private set; }

        [JsonProperty("PUMP")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PUMP { get; private set; }

        [JsonProperty("VET")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance VET { get; private set; }

        [JsonProperty("ARB")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ARB { get; private set; }

        [JsonProperty("JUP")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance JUP { get; private set; }

        [JsonProperty("BONK")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BONK { get; private set; }

        [JsonProperty("ZRO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ZRO { get; private set; }

        [JsonProperty("STX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance STX { get; private set; }

        [JsonProperty("SEI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SEI { get; private set; }

        [JsonProperty("EURC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance EURC { get; private set; }

        [JsonProperty("VIRTUAL")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance VIRTUAL { get; private set; }

        [JsonProperty("PENGU")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PENGU { get; private set; }

        [JsonProperty("KITE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance KITE { get; private set; }

        [JsonProperty("CAKE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance CAKE { get; private set; }

        [JsonProperty("XTZ")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance XTZ { get; private set; }

        [JsonProperty("JST")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance JST { get; private set; }

        [JsonProperty("ETHFI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ETHFI { get; private set; }

        [JsonProperty("FET")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance FET { get; private set; }

        [JsonProperty("CRV")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance CRV { get; private set; }

        [JsonProperty("IP")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance IP { get; private set; }

        [JsonProperty("KAIA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance KAIA { get; private set; }

        [JsonProperty("CHZ")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance CHZ { get; private set; }

        [JsonProperty("IMX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance IMX { get; private set; }

        [JsonProperty("LIT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance LIT { get; private set; }

        [JsonProperty("GNO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GNO { get; private set; }

        [JsonProperty("NFT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance NFT { get; private set; }

        [JsonProperty("AERO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance AERO { get; private set; }

        [JsonProperty("INJ")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance INJ { get; private set; }

        [JsonProperty("SUN")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SUN { get; private set; }

        [JsonProperty("PYTH")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PYTH { get; private set; }

        [JsonProperty("TIA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance TIA { get; private set; }

        [JsonProperty("H")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance H { get; private set; }

        [JsonProperty("IOTA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance IOTA { get; private set; }

        [JsonProperty("SPX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SPX { get; private set; }

        [JsonProperty("GRT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GRT { get; private set; }

        [JsonProperty("JASMY")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance JASMY { get; private set; }

        [JsonProperty("FLOKI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance FLOKI { get; private set; }

        [JsonProperty("FRAX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance FRAX { get; private set; }

        [JsonProperty("SYRUP")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SYRUP { get; private set; }

        [JsonProperty("OP")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance OP { get; private set; }

        [JsonProperty("LDO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance LDO { get; private set; }

        [JsonProperty("CFX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance CFX { get; private set; }

        [JsonProperty("ENS")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ENS { get; private set; }

        [JsonProperty("AXS")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance AXS { get; private set; }

        [JsonProperty("SAND")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SAND { get; private set; }

        [JsonProperty("MON")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MON { get; private set; }

        [JsonProperty("VVV")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance VVV { get; private set; }

        [JsonProperty("PENDLE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PENDLE { get; private set; }

        [JsonProperty("TWT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance TWT { get; private set; }

        [JsonProperty("WIF")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance WIF { get; private set; }

        [JsonProperty("NEO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance NEO { get; private set; }

        [JsonProperty("BARD")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BARD { get; private set; }

        [JsonProperty("MANA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MANA { get; private set; }

        [JsonProperty("THETA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance THETA { get; private set; }

        [JsonProperty("COMP")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance COMP { get; private set; }

        [JsonProperty("FF")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance FF { get; private set; }

        [JsonProperty("XCN")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance XCN { get; private set; }

        [JsonProperty("XPL")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance XPL { get; private set; }

        [JsonProperty("FARTCOIN")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance FARTCOIN { get; private set; }

        [JsonProperty("SENT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SENT { get; private set; }

        [JsonProperty("CVX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance CVX { get; private set; }

        [JsonProperty("RAY")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance RAY { get; private set; }

        [JsonProperty("BAT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BAT { get; private set; }

        [JsonProperty("TRAC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance TRAC { get; private set; }

        [JsonProperty("XEC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance XEC { get; private set; }

        [JsonProperty("RUNE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance RUNE { get; private set; }

        [JsonProperty("EGLD")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance EGLD { get; private set; }

        [JsonProperty("BERA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BERA { get; private set; }

        [JsonProperty("A")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance A { get; private set; }

        [JsonProperty("JTO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance JTO { get; private set; }

        [JsonProperty("WAL")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance WAL { get; private set; }

        [JsonProperty("DEEP")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance DEEP { get; private set; }

        [JsonProperty("MYX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MYX { get; private set; }

        [JsonProperty("S")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance S { get; private set; }

        [JsonProperty("SNX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SNX { get; private set; }

        [JsonProperty("EIGEN")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance EIGEN { get; private set; }

        [JsonProperty("COW")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance COW { get; private set; }

        [JsonProperty("LPT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance LPT { get; private set; }

        [JsonProperty("AR")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance AR { get; private set; }

        [JsonProperty("SKR")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SKR { get; private set; }

        [JsonProperty("BAN")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BAN { get; private set; }

        [JsonProperty("MELANIA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MELANIA { get; private set; }

        [JsonProperty("W")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance W { get; private set; }

        [JsonProperty("GAS")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GAS { get; private set; }

        [JsonProperty("ZEN")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ZEN { get; private set; }

        [JsonProperty("QTUM")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance QTUM { get; private set; }

        [JsonProperty("YZY")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance YZY { get; private set; }

        [JsonProperty("ROSE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ROSE { get; private set; }

        [JsonProperty("BEAM")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BEAM { get; private set; }

        [JsonProperty("RSR")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance RSR { get; private set; }

        [JsonProperty("MET")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MET { get; private set; }

        [JsonProperty("ZRX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ZRX { get; private set; }

        [JsonProperty("KSM")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance KSM { get; private set; }

        [JsonProperty("TOSHI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance TOSHI { get; private set; }

        [JsonProperty("CORE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance CORE { get; private set; }

        [JsonProperty("TSLAX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance TSLAX { get; private set; }

        [JsonProperty("ZORA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ZORA { get; private set; }

        [JsonProperty("ZIL")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ZIL { get; private set; }

        [JsonProperty("DYDX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance DYDX { get; private set; }

        [JsonProperty("APE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance APE { get; private set; }

        [JsonProperty("KAITO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance KAITO { get; private set; }

        [JsonProperty("MINA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MINA { get; private set; }

        [JsonProperty("CKB")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance CKB { get; private set; }

        [JsonProperty("FORM")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance FORM { get; private set; }

        [JsonProperty("T")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance T { get; private set; }

        [JsonProperty("SUPER")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SUPER { get; private set; }

        [JsonProperty("MOVE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MOVE { get; private set; }

        [JsonProperty("SOON")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SOON { get; private set; }

        [JsonProperty("BRETT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BRETT { get; private set; }

        [JsonProperty("ALEO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ALEO { get; private set; }

        [JsonProperty("GMX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GMX { get; private set; }

        [JsonProperty("NXPC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance NXPC { get; private set; }

        [JsonProperty("ACH")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ACH { get; private set; }

        [JsonProperty("TURBO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance TURBO { get; private set; }

        [JsonProperty("FLOW")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance FLOW { get; private set; }

        [JsonProperty("ALCH")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ALCH { get; private set; }

        [JsonProperty("ZETA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ZETA { get; private set; }

        [JsonProperty("AZTEC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance AZTEC { get; private set; }

        [JsonProperty("BTR")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BTR { get; private set; }

        [JsonProperty("SC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SC { get; private set; }

        [JsonProperty("SAHARA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SAHARA { get; private set; }

        [JsonProperty("SUSHI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SUSHI { get; private set; }

        [JsonProperty("GWEI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GWEI { get; private set; }

        [JsonProperty("VTHO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance VTHO { get; private set; }

        [JsonProperty("VELO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance VELO { get; private set; }

        [JsonProperty("PROVE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PROVE { get; private set; }

        [JsonProperty("GRASS")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GRASS { get; private set; }

        [JsonProperty("ME")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ME { get; private set; }

        [JsonProperty("BLUR")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BLUR { get; private set; }

        [JsonProperty("PYTHIA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PYTHIA { get; private set; }

        [JsonProperty("MEW")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MEW { get; private set; }

        [JsonProperty("ORCA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ORCA { get; private set; }

        [JsonProperty("KAVA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance KAVA { get; private set; }

        [JsonProperty("ORDI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ORDI { get; private set; }

        [JsonProperty("RED")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance RED { get; private set; }

        [JsonProperty("MOODENG")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MOODENG { get; private set; }

        [JsonProperty("REQ")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance REQ { get; private set; }

        [JsonProperty("ZAMA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ZAMA { get; private set; }

        [JsonProperty("LINEA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance LINEA { get; private set; }

        [JsonProperty("SPK")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SPK { get; private set; }

        [JsonProperty("B2")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance B2 { get; private set; }

        [JsonProperty("SSV")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SSV { get; private set; }

        [JsonProperty("POPCAT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance POPCAT { get; private set; }

        [JsonProperty("AVNT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance AVNT { get; private set; }

        [JsonProperty("DRIFT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance DRIFT { get; private set; }

        [JsonProperty("CELO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance CELO { get; private set; }

        [JsonProperty("GUN")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GUN { get; private set; }

        [JsonProperty("PNUT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PNUT { get; private set; }

        [JsonProperty("SOMI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SOMI { get; private set; }

        [JsonProperty("LRC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance LRC { get; private set; }

        [JsonProperty("BIO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BIO { get; private set; }

        [JsonProperty("BANANAS31")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BANANAS31 { get; private set; }

        [JsonProperty("LA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance LA { get; private set; }

        [JsonProperty("DUSK")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance DUSK { get; private set; }

        [JsonProperty("MASK")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MASK { get; private set; }

        [JsonProperty("ALT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ALT { get; private set; }

        [JsonProperty("PARTI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PARTI { get; private set; }

        [JsonProperty("ANKR")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ANKR { get; private set; }

        [JsonProperty("RPL")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance RPL { get; private set; }

        [JsonProperty("PUNDIX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PUNDIX { get; private set; }

        [JsonProperty("UMA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance UMA { get; private set; }

        [JsonProperty("BEAT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BEAT { get; private set; }

        [JsonProperty("ONT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ONT { get; private set; }

        [JsonProperty("GPS")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GPS { get; private set; }

        [JsonProperty("USELESS")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance USELESS { get; private set; }

        [JsonProperty("TRB")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance TRB { get; private set; }

        [JsonProperty("STORJ")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance STORJ { get; private set; }

        [JsonProperty("SKL")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SKL { get; private set; }

        [JsonProperty("METAX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance METAX { get; private set; }

        [JsonProperty("NVDAX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance NVDAX { get; private set; }

        [JsonProperty("MEME")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MEME { get; private set; }

        [JsonProperty("SIGN")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SIGN { get; private set; }

        [JsonProperty("ENJ")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ENJ { get; private set; }

        [JsonProperty("NOT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance NOT { get; private set; }

        [JsonProperty("GMT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GMT { get; private set; }

        [JsonProperty("ELON")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ELON { get; private set; }

        [JsonProperty("BAND")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BAND { get; private set; }

        [JsonProperty("ONE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ONE { get; private set; }

        [JsonProperty("BABY")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BABY { get; private set; }

        [JsonProperty("BREV")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BREV { get; private set; }

        [JsonProperty("CYBER")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance CYBER { get; private set; }

        [JsonProperty("CROSS")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance CROSS { get; private set; }

        [JsonProperty("ETHW")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ETHW { get; private set; }

        [JsonProperty("PEOPLE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PEOPLE { get; private set; }

        [JsonProperty("GLDX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GLDX { get; private set; }

        [JsonProperty("IO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance IO { get; private set; }

        [JsonProperty("COTI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance COTI { get; private set; }

        [JsonProperty("CVC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance CVC { get; private set; }

        [JsonProperty("AUCTION")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance AUCTION { get; private set; }

        [JsonProperty("SPELL")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SPELL { get; private set; }

        [JsonProperty("BIGTIME")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BIGTIME { get; private set; }

        [JsonProperty("MANTA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MANTA { get; private set; }

        [JsonProperty("ARC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ARC { get; private set; }

        [JsonProperty("NEIRO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance NEIRO { get; private set; }

        [JsonProperty("LAYER")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance LAYER { get; private set; }

        [JsonProperty("CLANKER")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance CLANKER { get; private set; }

        [JsonProperty("SXT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SXT { get; private set; }

        [JsonProperty("ONG")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ONG { get; private set; }

        [JsonProperty("ANIME")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ANIME { get; private set; }

        [JsonProperty("GIGGLE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GIGGLE { get; private set; }

        [JsonProperty("BOME")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BOME { get; private set; }

        [JsonProperty("LQTY")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance LQTY { get; private set; }

        [JsonProperty("MIRA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MIRA { get; private set; }

        [JsonProperty("API3")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance API3 { get; private set; }

        [JsonProperty("ARKM")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ARKM { get; private set; }

        [JsonProperty("EUL")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance EUL { get; private set; }

        [JsonProperty("WIN")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance WIN { get; private set; }

        [JsonProperty("METIS")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance METIS { get; private set; }

        [JsonProperty("ARIA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ARIA { get; private set; }

        [JsonProperty("RESOLV")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance RESOLV { get; private set; }

        [JsonProperty("HYPER")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance HYPER { get; private set; }

        [JsonProperty("SAPIEN")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SAPIEN { get; private set; }

        [JsonProperty("DIA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance DIA { get; private set; }

        [JsonProperty("USUAL")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance USUAL { get; private set; }

        [JsonProperty("WCT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance WCT { get; private set; }

        [JsonProperty("MAGIC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MAGIC { get; private set; }

        [JsonProperty("PHA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PHA { get; private set; }

        [JsonProperty("AIXBT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance AIXBT { get; private set; }

        [JsonProperty("GIGA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GIGA { get; private set; }

        [JsonProperty("TRADOOR")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance TRADOOR { get; private set; }

        [JsonProperty("XAI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance XAI { get; private set; }

        [JsonProperty("GOAT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GOAT { get; private set; }

        [JsonProperty("EDGE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance EDGE { get; private set; }

        [JsonProperty("SPACE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SPACE { get; private set; }

        [JsonProperty("DYM")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance DYM { get; private set; }

        [JsonProperty("XAN")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance XAN { get; private set; }

        [JsonProperty("VINE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance VINE { get; private set; }

        [JsonProperty("NEWT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance NEWT { get; private set; }

        [JsonProperty("ZKP")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ZKP { get; private set; }

        [JsonProperty("C")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance C { get; private set; }

        [JsonProperty("MPLX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MPLX { get; private set; }

        [JsonProperty("FIDA")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance FIDA { get; private set; }

        [JsonProperty("YB")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance YB { get; private set; }

        [JsonProperty("CATI")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance CATI { get; private set; }

        [JsonProperty("INIT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance INIT { get; private set; }

        [JsonProperty("DOGS")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance DOGS { get; private set; }

        [JsonProperty("FUN")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance FUN { get; private set; }

        [JsonProperty("STO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance STO { get; private set; }

        [JsonProperty("ZKJ")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ZKJ { get; private set; }

        [JsonProperty("MUBARAK")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MUBARAK { get; private set; }

        [JsonProperty("ACT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ACT { get; private set; }

        [JsonProperty("OGN")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance OGN { get; private set; }

        [JsonProperty("COOKIE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance COOKIE { get; private set; }

        [JsonProperty("BR")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BR { get; private set; }

        [JsonProperty("MAV")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance MAV { get; private set; }

        [JsonProperty("TREE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance TREE { get; private set; }

        [JsonProperty("NOM")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance NOM { get; private set; }

        [JsonProperty("ELIZAOS")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ELIZAOS { get; private set; }

        [JsonProperty("HFT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance HFT { get; private set; }

        [JsonProperty("HMSTR")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance HMSTR { get; private set; }

        [JsonProperty("SHELL")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SHELL { get; private set; }

        [JsonProperty("CHILLGUY")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance CHILLGUY { get; private set; }

        [JsonProperty("TOWNS")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance TOWNS { get; private set; }

        [JsonProperty("BMT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BMT { get; private set; }

        [JsonProperty("PORTAL")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PORTAL { get; private set; }

        [JsonProperty("EPIC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance EPIC { get; private set; }

        [JsonProperty("GRIFFAIN")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GRIFFAIN { get; private set; }

        [JsonProperty("HAEDAL")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance HAEDAL { get; private set; }

        [JsonProperty("ZEREBRO")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ZEREBRO { get; private set; }

        [JsonProperty("IDEX")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance IDEX { get; private set; }

        [JsonProperty("FWOG")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance FWOG { get; private set; }

        [JsonProperty("TAKE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance TAKE { get; private set; }

        [JsonProperty("PTB")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance PTB { get; private set; }

        [JsonProperty("UXLINK")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance UXLINK { get; private set; }

        [JsonProperty("SGB")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance SGB { get; private set; }

        [JsonProperty("BELIEVE")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BELIEVE { get; private set; }

        [JsonProperty("BTTC")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance BTTC { get; private set; }

        [JsonProperty("GORK")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance GORK { get; private set; }

        [JsonProperty("XAUT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance XAUT { get; private set; }

        [JsonProperty("ITALIANROT")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance ITALIANROT { get; private set; }

        [JsonProperty("0G")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance N0G { get; private set; }

        [JsonProperty("1000SATS")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance N1000SATS { get; private set; }

        [JsonProperty("1INCH")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance N1INCH { get; private set; }

        [JsonProperty("2Z")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance N2Z { get; private set; }

        [JsonProperty("67")]
        [JsonConverter(typeof(EntityJsonConverter<SymbolBalance>))]
        public SymbolBalance N67 { get; private set; }

        // Any new/unknown symbol returned by CEX.IO is stored here so Balance
        // stays forward-compatible with expanded symbol lists.
        [JsonExtensionData]
        private IDictionary<string, JToken> AdditionalSymbolBalances { get; set; }

        public bool TryGetSymbolBalance(Symbols symbol, out SymbolBalance balance)
            => TryGetSymbolBalance(symbol.ToString(), out balance);

        public bool TryGetSymbolBalance(string symbol, out SymbolBalance balance)
        {
            balance = null;

            if (string.IsNullOrWhiteSpace(symbol))
                return false;

            var normalized = symbol.ToUpperInvariant();
            var apiSymbol = normalized.ToApiSymbol();

            // First try direct Balance properties (BTC, USD, ...), then extension-data symbols.
            if (SymbolBalanceProperties.TryGetValue(normalized, out var propertyInfo))
            {
                balance = propertyInfo.GetValue(this) as SymbolBalance;
                if (balance != null)
                    return true;
            }

            if (AdditionalSymbolBalances != null &&
                AdditionalSymbolBalances.TryGetValue(apiSymbol, out var token) &&
                token != null &&
                token.Type == JTokenType.Object)
            {
                balance = token.ToObject<SymbolBalance>();
                return balance != null;
            }

            return false;
        }

        public IReadOnlyDictionary<Symbols, SymbolBalance> GetAvailableBalancesBySymbol()
        {
            var result = new Dictionary<Symbols, SymbolBalance>();

            foreach (var symbol in Enum.GetValues(typeof(Symbols)).Cast<Symbols>())
            {
                if (TryGetSymbolBalance(symbol, out var balance) && balance != null)
                    result[symbol] = balance;
            }

            return result;
        }
    }

    public class SymbolBalance : EntityBase
    {
        [JsonProperty("available")]
        public decimal Available { get; private set; }

        [JsonProperty("bonus")]
        public decimal Bonus { get; private set; }

        [JsonProperty("orders")]
        public decimal Orders { get; private set; }

        public SymbolBalance()
        {
        }

        public SymbolBalance(decimal available, decimal bonus, decimal orders)
        {
            Available = available;
            Bonus = bonus;
            Orders = orders;
        }
    }
}
