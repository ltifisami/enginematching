
using System;
using System.Collections.Generic;
using System.Linq;


namespace Engine
{
    // Class TradeTable contains the Order matched
    public class TradeTable
    {
        public static Dictionary<string, List<Order>> BuyTables = new Dictionary<string, List<Order>>();
        public static Dictionary<string, List<Order>> SellTables = new Dictionary<string, List<Order>>();
        private string sellOrderId;
        private Order orderTradeBuy;
        private int orderPriceBuy;
        private Devise deviseBuy;
        private string countryBuy;
        private DateTime dateCreateOrderBuy;
        private TimeSpan validityTimePeriodeBuy;
        private TimeSpan validityAbsoluteTimeBuy;

        private int orderQuantityTraded;

        private string buyOrderId;
        private Order orderTradeSell;
        private int orderPriceSell;
        private Devise deviseSell;
        private string countrySell;
        private DateTime dateCreateOrderSell;
        private TimeSpan validityTimePeriodeSell;
        private TimeSpan validityAbsoluteTimeSell;

        public Order OrderTradeBuy { get => orderTradeBuy; set => orderTradeBuy = value; }
        public int OrderPriceBuy { get => orderPriceBuy; set => orderPriceBuy = value; }
        public Devise DeviseBuy { get => deviseBuy; set => deviseBuy = value; }
        public string CountryBuy { get => countryBuy; set => countryBuy = value; }
        public DateTime DateCreateOrderBuy { get => dateCreateOrderBuy; set => dateCreateOrderBuy = value; }
        public TimeSpan ValidityTimePeriodeBuy { get => validityTimePeriodeBuy; set => validityTimePeriodeBuy = value; }
        public TimeSpan ValidityAbsoluteTimeBuy { get => validityAbsoluteTimeBuy; set => validityAbsoluteTimeBuy = value; }
       
         public int OrderQuantityTraded { get => orderQuantityTraded; set => orderQuantityTraded = value; }

        public Order OrderTradeSell { get => orderTradeSell; set => orderTradeSell = value; }
        public int OrderPriceSell { get => orderPriceSell; set => orderPriceSell = value; }
        public Devise DeviseSell { get => deviseSell; set => deviseSell = value; }
        public string CountrySell { get => countrySell; set => countrySell = value; }
        public DateTime DateCreateOrderSell { get => dateCreateOrderSell; set => dateCreateOrderSell = value; }
        public TimeSpan ValidityTimePeriodeSell { get => validityTimePeriodeSell; set => validityTimePeriodeSell = value; }
        public TimeSpan ValidityAbsoluteTimeSell { get => validityAbsoluteTimeSell; set => validityAbsoluteTimeSell = value; }
        public string SellOrderId { get => sellOrderId; set => sellOrderId = value; }
        public string BuyOrderId { get => buyOrderId; set => buyOrderId = value; }



        public TradeTable()
        {

            OrderTradeBuy = orderTradeBuy;
            OrderPriceBuy = orderPriceBuy;
            DeviseBuy = deviseBuy;
            CountryBuy = countryBuy;
            DateCreateOrderBuy = dateCreateOrderBuy;
            ValidityTimePeriodeBuy = validityTimePeriodeBuy;
            ValidityAbsoluteTimeBuy = validityAbsoluteTimeBuy;

            OrderQuantityTraded = orderQuantityTraded;

            OrderTradeSell = orderTradeSell;
            OrderPriceSell = orderPriceSell;
            DeviseSell = deviseSell;
            CountrySell = countrySell;
            DateCreateOrderSell = dateCreateOrderSell;
            ValidityTimePeriodeSell = validityTimePeriodeSell;
            ValidityAbsoluteTimeSell = validityAbsoluteTimeSell;
        }


        // Create BuyTables : BuyTable by Ticker
        public static Dictionary<string, List<Order>> CreateBuyTables()
        {
            foreach (var Ticker in BuyTable.ListBuyTicker())
            {
                BuyTables.Add(Ticker, BuyTable.GetBuyTableByTicker(Ticker));
            }
            return BuyTables;
        }


        // Create SellTables : SellTable by Ticker
        public static Dictionary<string, List<Order>> CreateSellTables()
        {
            foreach (var Ticker in SellTable.ListSellTicker())
            {
                SellTables.Add(Ticker, SellTable.GetSellTableByTicker(Ticker));
            }
            return SellTables;
        }


        public static void AddBuyOrderInBuyTables(List<Order> buyTable ,Order _order)
        {
            if (!BuyTables.ContainsKey(_order.Ticker))
            {
                buyTable.Add(_order);
                BuyTables.Add(_order.Ticker, buyTable);
            }else
            {
                buyTable.Add(_order);
            }
        }

        public static void AddSellOrderInSellTables(List<Order> sellTable, Order _order)
        {
            if (!SellTables.ContainsKey(_order.Ticker))
            {
                sellTable.Add(_order);
                SellTables.Add(_order.Ticker, sellTable);
            }
            else
            {
                sellTable.Add(_order);
            }
        }



        // chek the validity of the Trade
        public static bool IsTrade()
        {
            if (BuyTables.Equals(0) || SellTables.Equals(0)) return false;
                int i = 0;
                foreach (var key in BuyTables.Keys)
                {
                    Console.WriteLine("key ===>" + key);
                if (SellTables.ContainsKey(key)) i++;
            }
            if (!BuyTables.Equals(0) && !SellTables.Equals(0) && i != 0) return true;

            return false;
        }


       public static bool IsValidTrade(string operation, string[] operation_statement_array)
        {
            if (operation.Equals(Operation_type.BUY.ToString())
                || operation.Equals(Operation_type.SELL.ToString()))

            {
                //return true if arguments passed are 11
                if (operation_statement_array.Length.Equals(11)) return true;
            }
            else if (operation.Equals(Operation_type.MODIFY.ToString()))
            {

                //return true if arguments passed are 5
                if (operation_statement_array.Length.Equals(5)) return true;
            }
            else if (operation.Equals(Operation_type.CANCEL.ToString()))
            {
                //return true if arguments passed are 2
                if (operation_statement_array.Length.Equals(2)) return true;
            }
            else if (operation.Equals(Operation_type.PRINT.ToString()))
            {
                //return true if arguments passed are 1
                if (operation_statement_array.Length.Equals(1)) return true;
            }


            return false;
        }





        // return a minimum between two integers
       public static int ReturnLeastNumber(int a, int b)
        {
            //int min = 0;
            if (a <= b) return a;
            else return b;

        }


        // Modify Table
        public static void ModifyOrder(Order order, int numTraded)
        {

            if (order.OperationType == Operation_type.SELL)
            {
                //(currentSellOrderID, operation_type.SELL, currentSellOrderPrice, num_traded, currentSellOrderType);
                if (TradeTable.SellTables[order.Ticker].Contains(order))
                {

                    var temp = order.OrderQuantity - numTraded;



                    if (temp <= 0)
                    {
                        OrderBook.Selltable.Remove(order);
                    }
                    else
                    {
                        order.OrderQuantity = order.OrderQuantity - numTraded;
                    }

                }

            }
            if (order.OperationType == Operation_type.BUY)
            {

                if (TradeTable.BuyTables[order.Ticker].Contains(order))
                {

                    var temp = order.OrderQuantity - numTraded;
                    Console.WriteLine("temp **** Buytable ====>" + temp);
                    if (temp<= 0)
                    {
                        Console.WriteLine("OrderBook.Buytable.Remove(order)");
                        OrderBook.Buytable.Remove(order);
                    }
                    else
                    {

                        order.OrderQuantity = order.OrderQuantity - numTraded;
                    }



                }

            }



        }

    }
}
