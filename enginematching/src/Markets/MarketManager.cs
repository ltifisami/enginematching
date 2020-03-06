
using System;
using System.Collections.Generic;
using Engine;

namespace Markets
{
    // MarketManager implements IMarketManager
    public class MarketManager : IMarketManager
    {

        private Dictionary<string, Market> markets = new Dictionary<string, Market>() ;
        public Dictionary<string, Market> Markets { get => markets; set => markets = value; }

        public MarketManager()
        {
            Markets = markets;

        }

        public void CreateMarket(int fixingPeriod, DateTime marketInitDate, int maxQuantity, int minQuantity, Quantity description, float priceDelta, PriceDeltaRange priceDeltaRanger, BuyTable buyTable, SellTable sellTable, SettlementTable settlementTable, TradeTable tradeTable , Matching_Type matchingType)
        {
          
            Market market = new Market( fixingPeriod, maxQuantity, marketInitDate, minQuantity, description, priceDelta, priceDeltaRanger, buyTable, sellTable, settlementTable, tradeTable, matchingType);
            Markets.Add(market.Ticker, market);
        }

      
        public void AddMarket(Market market)
        {
            if (!Markets.ContainsKey(market.Ticker))
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

        public void UpdateMarketByTicker(string Ticker, int fixingPeriod, DateTime marketInitDate, int maxQuantity, int minQuantity, Quantity description, float priceDelta, PriceDeltaRange priceDeltaRanger, BuyTable buyTable, SellTable sellTable, SettlementTable settlementTable, TradeTable tradeTable,Matching_Type matchingType)
        {
            Market marketToUpdate = this.GetMarketByTicker(Ticker);
            Market marketUpdated = new Market( fixingPeriod, maxQuantity, marketInitDate, minQuantity, description, priceDelta, priceDeltaRanger, buyTable, sellTable, settlementTable, tradeTable, matchingType);
            // delete MarketToUpdate from a Markets collections
            this.DeleteMarketByTicker(Ticker);
            //add the marketUpdated in the Markets 
            Markets.Add(Ticker, marketUpdated);
        }

        // Return MatchingType by Ticker
        public  string GetMatchingTypeByTicker(string Ticker)
        {
            Market market = GetMarketByTicker( Ticker);
            if (market.MatchingType == Matching_Type.FIXING) return "FIXING";
            else if (market.MatchingType == Matching_Type.MANUAL) return "MANUAL";
            else return "MarketPlace";
        }

      
    }

}


