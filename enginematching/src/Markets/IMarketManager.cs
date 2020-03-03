using System;
using System.Collections.Generic;
using Engine;

namespace Markets
{
    // Interface IMarketManager
    public interface IMarketManager
    {
         // Creates and adds a Market in Markets Collection
         void CreateMarket(int fixingPeriod, DateTime marketInitDate, int maxQuantity, int minQuantity, Quantity description, float priceDelta, PriceDeltaRange priceDeltaRanger, BuyTable buyTable, SellTable sellTable, SettlementTable settlementTable, TradeTable tradeTable , Matching_Type matchingType);
        // Return a Market by Ticker
          Market GetMarketByTicker(string Ticker);
        // Update a Market by Ticker in Markets
          void UpdateMarketByTicker(string Ticker, int fixingPeriod, DateTime marketInitDate, int maxQuantity, int minQuantity, Quantity description, float priceDelta, PriceDeltaRange priceDeltaRanger, BuyTable buyTable, SellTable sellTable, SettlementTable settlementTable, TradeTable tradeTable, Matching_Type matchingType);
         //Delete a Market from the Marktes
         bool DeleteMarketByTicker(string Ticker);
        // Return MatchingType by Ticker
        string GetMatchingTypeByTicker(string Ticker);
        // Add a Market to a Marktes
        void AddMarket(Market market); 





    }
}
