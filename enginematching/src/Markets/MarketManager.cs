
using System;
using System.Collections.Generic;
using Engine;

namespace Markets
{
    // MarketManager implements IMarketManager
    public class MarketManager : IMarketManager
    {

        private IDictionary<string, Market> markets;
        public IDictionary<string, Market> Markets { get => markets; set => markets = value; }

        public MarketManager()
        {
            Markets = markets;

        }

        public void CreateMarket(int fixingPeriod, DateTime marketInitDate, int maxQuantity, int minQuantity, Quantity description, float priceDelta, PriceDeltaRange priceDeltaRanger, BuyTable buyTable, SellTable sellTable, SettlementTable settlementTable, TradeTable tradeTable)
        {
          
            Market market = new Market( fixingPeriod, maxQuantity, marketInitDate, minQuantity, description, priceDelta, priceDeltaRanger, buyTable, sellTable, settlementTable, tradeTable);
            Markets.Add(market.Ticker, market);
        }

        public bool DeleteMarketByTicker(string Ticker)
        {
            if (this.Markets.Remove(Ticker))
                return true;
            else return false;
        }

        public Market GetMarketByTicker(string Ticker)
        {
            return Markets[Ticker];
        }

        public void UpdateMarketByTicker(string Ticker, int fixingPeriod, DateTime marketInitDate, int maxQuantity, int minQuantity, Quantity description, float priceDelta, PriceDeltaRange priceDeltaRanger, BuyTable buyTable, SellTable sellTable, SettlementTable settlementTable, TradeTable tradeTable)
        {
            Market marketToUpdate = this.GetMarketByTicker(Ticker);
            Market marketUpdated = new Market( fixingPeriod, maxQuantity, marketInitDate, minQuantity, description, priceDelta, priceDeltaRanger, buyTable, sellTable, settlementTable, tradeTable);
            // delete MarketToUpdate from a Markets collections
            this.DeleteMarketByTicker(Ticker);
            //add the marketUpdated in the Markets 
            Markets.Add(Ticker, marketUpdated);
        }
    }

}


