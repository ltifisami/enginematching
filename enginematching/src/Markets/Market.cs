
using System;
using System.Collections.Generic;
using Engine;
using Products;

namespace Markets
{

    //enumerator list for the type of order
    public enum Order_type { IOC, GFD, INV, ICB, DRT, BPR };
    // enumerator list for the type of trade
    public enum Operation_type { BUY, SELL, CANCEL, PRINT, MODIFY };
    //enumerator list for Currency
    public enum Devise { EUR, GBD, YEN, CHF, USD, REM_reminbi };
    // enumerator list for UNIT 
    public enum Quantity { TONS, UNIT };
    // Enumerator List for Matching Type
    public enum  Matching_Type { MANUAL , MarketPlace_AVEREGE, MarketPlace_BESTBUY, MarketPlace_BESTSELL ,FIXING };


    // Class Market 
    public class Market
    {
        private string ticker;
        // fixingPeriod is expressed in seconds
        private bool directPartialOrderMatchingEnable;
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
        private Matching_Type matchingType;

        //Constructor Market
        public Market()
        {
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
            DirectPartialOrderMatchingEnable = directPartialOrderMatchingEnable;
        }

        // Constructor with parameters useful for update

        public Market( int fixingPeriod, int maxQuantity, DateTime marketInitDate, int minQuantity, Quantity description, float priceDelta, PriceDeltaRange priceDeltaRanger, BuyTable buyTable, SellTable sellTable, SettlementTable settlementTable, TradeTable tradeTable ,Matching_Type matchingType)
        {
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
            MatchingType = matchingType;
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
        public Matching_Type MatchingType { get => matchingType; set => matchingType = value; }
        public bool DirectPartialOrderMatchingEnable{ get => directPartialOrderMatchingEnable; set => directPartialOrderMatchingEnable = value; }

        // Return a Product By Ticker
        public Product GetProduct(string Ticker)
        {
            Product p = new Product();
            return Product.GetProductByTicker(Ticker);
        }

                // Send an Order

        public void SendOrder()
        {
            // Create an instance of class Matching
            Matching matching = new Matching();

            string[] orderArray = new string[] { };

            // Create a Command line
            List<string> OrderInput = Command.OrderInput();

            foreach (var line in OrderInput)
            {
                orderArray = line.Split(null);

                 

                //Checks if the Trade statement is right
                if (matching.IsValidOrder(orderArray[0], orderArray))
                {
                   
                    switch (orderArray[0])
                    {

                        case "BUY":
                            {
                                //BUY Operation logic
                                try
                                {
                                    Order _Order = new Order();
                                    _Order = _Order.CreateOrder(orderArray);
                                    OrderBook.OrderBookCollection.Add(Convert.ToString(orderArray[9]), _Order);
                                    BuyTable.Buytable.Add(_Order);
                                    BuyTable.AddBuyOrderInBuyTables(_Order);

                                }
                                catch
                                {
                                    Console.WriteLine("Error?");
                                }
                                break;
                            }

                        case "SELL":
                            {

                                //SELL Operation logic
                                try
                                {
                                    Order _Order = new Order();
                                    _Order = _Order.CreateOrder(orderArray);
                                    OrderBook.AddOrder(orderArray[9], _Order);
                                    SellTable.Selltable.Add(_Order);
                                    SellTable.AddSellOrderInSellTables(_Order);
                                }
                                catch
                                {
                                    Console.WriteLine("Repeated?");
                                }
                                break;
                            }

                        case "CANCEL":
                            {
                                //CANCEL Operation logic
                                //Removing Sell and BUY tabel entry

                                if (SellTable.Selltable.Contains(OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])]))
                                {
                                    SellTable.Selltable.Remove(OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])]);
                                    OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])].Statue = Statue.CANCELLED;

                                }
                                else if (BuyTable.Buytable.Contains(OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])]))
                                {
                                    BuyTable.Buytable.Remove(OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])]);
                                    OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])].Statue = Statue.CANCELLED;
                                }

                                break;
                            }

                        case "MODIFY":
                            {
                                matching.ModifyOrder(orderArray);
                                break;

                            }
                        case "MATCH":
                            {
                                if(orderArray[1].Equals("EXISTING") && orderArray[2].Equals("ORDER"))
                                { 
                                bool authorizationUser = DirectPartialOrderMatchingEnable;
                                matching.MatchingExistingOrder(orderArray , authorizationUser ,this.MatchingType);
                                }
                                break;
                            }

                        default:
                            break;
                    }
                }

            }

            try
            {
                //Let's Trade
                if (orderArray[0] == "PRINT" && matching.IsTrade())
                {
                    matching.MatchOrder(this.MatchingType);
                }

                // Check for SELL AND BUY Tables for suitable trades.
                else if (!matching.IsTrade() && orderArray[0] == "PRINT")
                {
                    matching.PrintOperation();
                }

                else if (matching.IsTrade())
                {
                   
                    matching.MatchOrder(this.MatchingType);

                }
               
            }
            catch
            { Console.ReadKey(); }
            Console.ReadKey();
        }

    }

    }


