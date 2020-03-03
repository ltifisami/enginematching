using System;
using Engine;

namespace Markets
{
    // class Facade MarketManager
    public class MarketManagerFacade
    {

        private IMarketManager marketManager ;

      
        public MarketManagerFacade()
        {
            marketManager = new MarketManager ();
        }

        public void CreateMarket(int fixingPeriod, DateTime marketInitDate, int maxQuantity, int minQuantity, Quantity description, float priceDelta, PriceDeltaRange priceDeltaRanger, BuyTable buyTable, SellTable sellTable, SettlementTable settlementTable, TradeTable tradeTable,Matching_Type matchingType)
        {
            marketManager.CreateMarket(fixingPeriod,marketInitDate, maxQuantity, minQuantity,  description,  priceDelta, priceDeltaRanger, buyTable,sellTable,settlementTable, tradeTable,matchingType);
        }

        public bool DeleteMarketByTicker(string Ticker)
        {
            return marketManager.DeleteMarketByTicker(Ticker);
        }

        public Market GetMarketByTicker(string Ticker)
        {
            return marketManager.GetMarketByTicker(Ticker);
        }

        public void UpdateMarketByTicker(string Ticker, int fixingPeriod, DateTime marketInitDate, int maxQuantity, int minQuantity, Quantity description, float priceDelta, PriceDeltaRange priceDeltaRanger, BuyTable buyTable, SellTable sellTable, SettlementTable settlementTable, TradeTable tradeTable, Matching_Type matchingType)
        {
            marketManager.UpdateMarketByTicker(Ticker, fixingPeriod, marketInitDate, maxQuantity, minQuantity, description, priceDelta, priceDeltaRanger, buyTable, sellTable, settlementTable, tradeTable,matchingType);
        }

        public string GetMatchingTypeByTicker(string Ticker)
        {
           return marketManager.GetMatchingTypeByTicker(Ticker);

        }

        public void AddMarket(Market market)
        {
            marketManager.AddMarket(market);
        }



    }
}