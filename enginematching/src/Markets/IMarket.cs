using System;
using Engine;
using Products;

namespace Markets
{
    public interface IMarket
    {

        string Ticker { get; set ; }
        int FixingPeriod { get; set; }
        int MaxQuantity { get; set; }
        DateTime MarketInitDate { get; set; }
        int MinQuantity { get; set; }
        Quantity Description { get; set; }
        float PriceDelta { get; set; }
        PriceDeltaRange PriceDeltaRanger { get; set; }
        BuyTable BuyTable { get; set; }
        SellTable SellTable { get; set; }
        SettlementTable SettlementTable { get; set; }
        TradeTable TradeTable { get; set; }
        Matching_Type MatchingType { get; set; }
        bool DirectPartialOrderMatchingEnable { get; set; }
        Product GetProduct(string Ticker);
        string GetMatchingTypeByTicker();
        void SendOrder();
    }
}
