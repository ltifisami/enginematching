
using System;
using System.Collections.Generic;


namespace enginematching
{
    public class MarketManager
    {

        private IDictionary<string, Market> markets;
        public IDictionary<string, Market> Markets { get => markets; set => markets = value; }


        // CreateMarket creates a Market and adds it to th Markets Collection
        public void CreateMarket(string Ticker,
                                        int fixingPeriod,
                                         DateTime marketInitDate,
                                         int maxQuantity,
                                        int minQuantity,
                                         Quantity description,
                                         float priceDelta,
                                         PriceDeltaRange priceDeltaRanger,
                                         BuyTable buyTable,
                                         SellTable sellTable,
                                          SettlementTable settlementTable,
                                          TradeTable tradeTable)
        {
            Market market = new Market(Ticker, fixingPeriod, maxQuantity, marketInitDate, minQuantity, description, priceDelta, priceDeltaRanger, buyTable, sellTable, settlementTable, tradeTable);
            Markets.Add(Ticker, market);
        }

        // return a Market by Ticker
        public Market GetMarketByTicker(string Ticker)
        {
            return Markets[Ticker];
        }

        // this method updates a Market by Ticker and updates the Markets Collection 
        public void UpdateMarketByTicker(string Ticker,
                                        int fixingPeriod,
                                         DateTime marketInitDate,
                                         int maxQuantity,
                                        int minQuantity,
                                         Quantity description,
                                         float priceDelta,
                                         PriceDeltaRange priceDeltaRanger,
                                         BuyTable buyTable,
                                         SellTable sellTable,
                                          SettlementTable settlementTable,
                                          TradeTable tradeTable)
        {
            Market marketToUpdate = this.GetMarketByTicker(Ticker);
            Market marketUpdated = new Market(Ticker, fixingPeriod, maxQuantity, marketInitDate, minQuantity, description, priceDelta, priceDeltaRanger, buyTable, sellTable, settlementTable, tradeTable);
            // delete MarketToUpdate from a Markets collections
            this.DeleteMarketByTicker(Ticker);
            //add the marketUpdated in the Markets 
            Markets.Add(Ticker, marketUpdated);


        }

        // DeleteMarketByTicker return true if the Market is Deleted and return false if not 
        public bool DeleteMarketByTicker(string Ticker)
        {
            if (this.Markets.Remove(Ticker))
                return true;
            else return false;

        }
    }

}
