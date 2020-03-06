
using System;
using System.Collections.Generic;
using System.Linq;
using Markets;

namespace Engine
{
    // Class TradeTable contains the Order matched
    public class TradeTable
    {
       private string originalAskOrderId;
        private Order originalAskTrade;
        private int originalAskOrderPrice;
        private Devise originalAskDevise;
        private string originalAskCountry;
        private DateTime originalAskDateCreate;
        private DateTime originalAskDateEnd;

        private int tradedQuantity;
        private float tradedPrice;

        private string originalBidOrderId;
        private Order originalBidTrade;
        private int originalBidOrderPrice;
        private Devise originalBidDevise;
        private string originalBidCountry;
        private DateTime originalBidDateCreate;
        private DateTime originalBidDateEnd;

        public string OriginalAskOrderId { get => originalAskOrderId; set => originalAskOrderId = value; }
        public Order OriginalAskTrade { get => originalAskTrade; set => originalAskTrade = value; }
        public int OriginalAskOrderPrice { get => originalAskOrderPrice; set => originalAskOrderPrice = value; }
        public Devise OriginalAskDevise { get => originalAskDevise; set => originalAskDevise = value; }
        public string OriginalAskCountry { get => originalAskCountry; set => originalAskCountry = value; }
        public DateTime OriginalAskDateCreate { get => originalAskDateCreate; set => originalAskDateCreate = value; }
        public DateTime OriginalAskDateEnd { get => originalAskDateEnd; set => originalAskDateEnd = value; }




        public int TradedQuantity { get => tradedQuantity; set => tradedQuantity = value; }
        public float TradedPrice { get => tradedPrice; set => tradedPrice = value; }


        public string OriginalBidOrderId { get => originalBidOrderId; set => originalBidOrderId = value; }
        public Order OriginalBidTrade { get => originalBidTrade; set => originalBidTrade = value; }
        public int OriginalBidOrderPrice { get => originalBidOrderPrice; set => originalBidOrderPrice = value; }
        public Devise OriginalBidDevise { get => originalBidDevise; set => originalBidDevise = value; }
        public string OriginalBidCountry { get => originalBidCountry; set => originalBidCountry = value; }
        public DateTime OriginalBidDateCreate { get => originalBidDateCreate; set => originalBidDateCreate = value; }
        public DateTime OriginalBidDateEnd { get => originalBidDateEnd; set => originalBidDateEnd = value; }


        public TradeTable()
        {
            OriginalAskOrderId = originalAskOrderId;
            OriginalAskOrderPrice = originalAskOrderPrice;
            OriginalAskDevise = originalAskDevise;
            OriginalAskCountry = originalAskCountry;

            TradedQuantity = tradedQuantity;
            TradedPrice = tradedPrice;

            OriginalBidOrderId = originalBidOrderId;
            OriginalBidOrderPrice = originalBidOrderPrice;
            OriginalBidDevise = originalBidDevise;
            OriginalBidCountry = originalBidCountry;
        }



         // Creates a tradeTable and adds it in TradeTable depending on Matching Type

        public static void AddTradeTable(IOrder buyOrder, IOrder sellOrder, int num_traded , Matching_Type matching_Type)
        {
            TradeTable tradeTable = new TradeTable
            {
                OriginalAskOrderId = buyOrder.OrderId,
                OriginalAskOrderPrice = buyOrder.OrderPrice,
                OriginalAskDevise = buyOrder.Devise,
                OriginalAskCountry = buyOrder.Country,
                TradedQuantity = num_traded,
                OriginalBidOrderId = sellOrder.OrderId,
                OriginalBidOrderPrice = sellOrder.OrderPrice,
                OriginalBidDevise = sellOrder.Devise,
                OriginalBidCountry = sellOrder.Country


            };
            switch (matching_Type)
            {
                case Matching_Type.MANUAL:
                    tradeTable.TradedPrice = buyOrder.OrderPrice;
                    // Add the _tradeTable in Tradetable 
                    Matching.Tradetable.Add(tradeTable);
                    break;
                case Matching_Type.MarketPlace_AVEREGE:
                    tradeTable.TradedPrice = (buyOrder.OrderPrice + sellOrder.OrderPrice) / 2;
                    // Add the _tradeTable in Tradetable 
                    Matching.Tradetable.Add(tradeTable);
                    break;
                case Matching_Type.MarketPlace_BESTBUY:
                    tradeTable.TradedPrice = sellOrder.OrderPrice;
                    // Add the _tradeTable in Tradetable 
                    Matching.Tradetable.Add(tradeTable);
                    break;
                case Matching_Type.MarketPlace_BESTSELL:
                    tradeTable.TradedPrice = buyOrder.OrderPrice;
                    // Add the _tradeTable in Tradetable 
                    Matching.Tradetable.Add(tradeTable);
                    break;
                case Matching_Type.FIXING:
                    break;
            }
        }

    }
}
