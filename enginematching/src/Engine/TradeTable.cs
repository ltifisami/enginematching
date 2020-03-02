
using System;
using System.Collections.Generic;
using System.Linq;


namespace Engine
{
    // Class TradeTable contains the Order matched
    public class TradeTable
    {
        public static List<IOrder> Buytable = new List<IOrder>();
        public static List<IOrder> Selltable = new List<IOrder>();
        public static Dictionary<string, List<IOrder>> BuyTables = new Dictionary<string, List<IOrder>>();
        public static Dictionary<string, List<IOrder>> SellTables = new Dictionary<string, List<IOrder>>();
        private string sellOrderId;
        private Order orderTradeBuy;
        private int orderPriceBuy;
        private Devise deviseBuy;
        private string countryBuy;
        private DateTime dateCreateOrderBuy;
        private DateTime dateEndOrderBuy;
        private int orderQuantityTraded;

        private string buyOrderId;
        private Order orderTradeSell;
        private int orderPriceSell;
        private Devise deviseSell;
        private string countrySell;
        private DateTime dateCreateOrderSell;
        private DateTime dateEndOrderSell;


        public string BuyOrderId { get => buyOrderId; set => buyOrderId = value; }
        public Order OrderTradeBuy { get => orderTradeBuy; set => orderTradeBuy = value; }
        public int OrderPriceBuy { get => orderPriceBuy; set => orderPriceBuy = value; }
        public Devise DeviseBuy { get => deviseBuy; set => deviseBuy = value; }
        public string CountryBuy { get => countryBuy; set => countryBuy = value; }
        public DateTime DateCreateOrderBuy { get => dateCreateOrderBuy; set => dateCreateOrderBuy = value; }
        public DateTime DateEndOrderBuy { get => dateEndOrderBuy; set => dateEndOrderBuy = value; }
      
        public int OrderQuantityTraded { get => orderQuantityTraded; set => orderQuantityTraded = value; }

        public string SellOrderId { get => sellOrderId; set => sellOrderId = value; }
        public Order OrderTradeSell { get => orderTradeSell; set => orderTradeSell = value; }
        public int OrderPriceSell { get => orderPriceSell; set => orderPriceSell = value; }
        public Devise DeviseSell { get => deviseSell; set => deviseSell = value; }
        public string CountrySell { get => countrySell; set => countrySell = value; }
        public DateTime DateCreateOrderSell { get => dateCreateOrderSell; set => dateCreateOrderSell = value; }
        public DateTime DateEndOrderSell { get => dateEndOrderSell; set => dateEndOrderSell = value; }

        public TradeTable()
        {

            OrderTradeBuy = orderTradeBuy;
            OrderPriceBuy = orderPriceBuy;
            DeviseBuy = deviseBuy;
            CountryBuy = countryBuy;
            DateCreateOrderBuy = dateCreateOrderBuy;
            DateEndOrderBuy = dateEndOrderBuy;

            OrderQuantityTraded = orderQuantityTraded;

            OrderTradeSell = orderTradeSell;
            OrderPriceSell = orderPriceSell;
            DeviseSell = deviseSell;
            CountrySell = countrySell;
            DateCreateOrderSell = dateCreateOrderSell;
            DateEndOrderSell = dateEndOrderSell;
           
        }



        public static void AddBuyOrderInBuyTables(Order _order)
        {
            if (!BuyTables.ContainsKey(_order.Ticker))
            {
                List<IOrder> _Buytable = new List<IOrder>
                {
                    _order
                };
                BuyTables.Add(_order.Ticker, _Buytable);
            }else
            {
                BuyTables[_order.Ticker].Add(_order);
            }
        }

        public static void AddSellOrderInSellTables(Order _order)
        {
            if (!SellTables.ContainsKey(_order.Ticker))
            {
                List<IOrder> _Selltable = new List<IOrder>
                {
                    _order
                };
                SellTables.Add(_order.Ticker, _Selltable);
            }
            else
            {
                SellTables[_order.Ticker].Add(_order);
            }
        }



        // chek the validity of the Trade
        public static bool IsTrade()
        {
            if (BuyTables.Equals(0) || SellTables.Equals(0)) return false;
                int i = 0;
                foreach (var key in BuyTables.Keys)
                {
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
                if (operation_statement_array.Length.Equals(10)) return true;
            }
            else if (operation.Equals(Operation_type.MODIFY.ToString()))
            {

                //return true if arguments passed are 5
                if (operation_statement_array.Length.Equals(10)) return true;
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
        public static void ModifyOrder(IOrder order, int numTraded)
        {

            if (order.OperationType == Operation_type.SELL)
            {
                //(currentSellOrderID, operation_type.SELL, currentSellOrderPrice, num_traded, currentSellOrderType);
                if (TradeTable.SellTables[order.Ticker].Contains(order))
                {

                    var temp = order.OrderQuantity - numTraded;



                    if (temp <= 0)
                    {
                        Selltable.Remove(order);
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

                    if (temp<= 0)
                    {
                     
                        Buytable.Remove(order);
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
