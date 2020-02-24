using System;


namespace Markets
{
    // class Facade MarketManager
    public class MarketManagerFacade
    {

        private MarketManager marketManager ;
        public MarketManager MarketManager { get => marketManager; set => marketManager = value; }


        public MarketManagerFacade()
        {
            MarketManager = new MarketManager();
        }

        public void CreateMarket(int fixingPeriod, DateTime marketInitDate, int maxQuantity, int minQuantity, Quantity description, float priceDelta, PriceDeltaRange priceDeltaRanger, BuyTable buyTable, SellTable sellTable, SettlementTable settlementTable, TradeTable tradeTable)
        {
            MarketManager.CreateMarket(fixingPeriod,marketInitDate, maxQuantity, minQuantity,  description,  priceDelta, priceDeltaRanger, buyTable,sellTable,settlementTable,tradeTable);
        }

        public bool DeleteMarketByTicker(string Ticker)
        {
            return MarketManager.DeleteMarketByTicker(Ticker);
        }

        public Market GetMarketByTicker(string Ticker)
        {
            return MarketManager.GetMarketByTicker(Ticker);
        }

        public void UpdateMarketByTicker(string Ticker, int fixingPeriod, DateTime marketInitDate, int maxQuantity, int minQuantity, Quantity description, float priceDelta, PriceDeltaRange priceDeltaRanger, BuyTable buyTable, SellTable sellTable, SettlementTable settlementTable, TradeTable tradeTable)
        {
            MarketManager.UpdateMarketByTicker(Ticker, fixingPeriod, marketInitDate, maxQuantity, minQuantity, description, priceDelta, priceDeltaRanger, buyTable, sellTable, settlementTable, tradeTable);
        }

    }
}