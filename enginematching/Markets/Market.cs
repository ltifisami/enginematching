﻿
using System;


namespace enginematching
{
    // Class Market 
    public class Market
    {

        private string ticker;
        // fixingPeriod is expressed in seconds
        private int fixingPeriod;
        private DateTime marketInitDate;
        private int maxQuantity;
        private int minQuantity;
        private Quantity description;
        private float priceDelta;
        private PriceDeltaRange priceDeltaRanger;
        private BuyTable buyTable;
        private SellTable sellTable;
        private SettlementTable settlementTable;
        private TradeTable tradeTable;

        //Constructor Market
        public Market()
        {

            Ticker = ticker;
            FixingPeriod = fixingPeriod;
            MaxQuantity = maxQuantity;
            MarketInitDate = marketInitDate;
            MinQuantity = minQuantity;
            Description = description;
            PriceDelta = priceDelta;
            PriceDeltaRanger = priceDeltaRanger;
            BuyTable = buyTable;
            SellTable = sellTable;
            TradeTable = tradeTable;
            SettlementTable = settlementTable;

        }

        //Constructor with parameters useful for update
        public Market(string ticker, int fixingPeriod, int maxQuantity, DateTime marketInitDate, int minQuantity, Quantity description, float priceDelta, PriceDeltaRange priceDeltaRanger, BuyTable buyTable, SellTable sellTable, SettlementTable settlementTable, TradeTable tradeTable)
        {
            Ticker = ticker;
            FixingPeriod = fixingPeriod;
            MaxQuantity = maxQuantity;
            MarketInitDate = marketInitDate;
            MinQuantity = minQuantity;
            Description = description;
            PriceDelta = priceDelta;
            PriceDeltaRanger = priceDeltaRanger;
            BuyTable = buyTable;
            SellTable = sellTable;
            SettlementTable = settlementTable;
            TradeTable = tradeTable;
        }

        public string Ticker { get => ticker; set => ticker = value; }
        public int FixingPeriod { get => fixingPeriod; set => fixingPeriod = value; }
        public int MaxQuantity { get => maxQuantity; set => maxQuantity = value; }
        public DateTime MarketInitDate { get => marketInitDate; set => marketInitDate = value; }
        public int MinQuantity { get => minQuantity; set => minQuantity = value; }
        public Quantity Description { get => description; set => description = value; }
        public float PriceDelta { get => priceDelta; set => priceDelta = value; }
        public PriceDeltaRange PriceDeltaRanger { get => priceDeltaRanger; set => priceDeltaRanger = value; }
        public BuyTable BuyTable { get => buyTable; set => buyTable = value; }
        public SellTable SellTable { get => sellTable; set => sellTable = value; }
        public SettlementTable SettlementTable { get => settlementTable; set => settlementTable = value; }
        public TradeTable TradeTable { get => tradeTable; set => tradeTable = value; }


        public Product GetProduct(string Ticker)
        {
            Product p = new Product();
            return Product.GetProductByTicker(Ticker);
        }



    }

}