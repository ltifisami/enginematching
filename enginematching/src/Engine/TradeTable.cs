
using System;
using System.Collections.Generic;
using System.Linq;


namespace Engine
{
    // Class TradeTable contains the Order matched
    public class TradeTable
    {
        public static Dictionary<string, BuyTable> BuyTables = new Dictionary<string, BuyTable>()  ;
        public static Dictionary<string, SellTable> SellTables = new Dictionary<string, SellTable>()  ;


        private Order orderTradeBuy;
        private int orderQuantityBuy;
        private int orderPriceBuy;
        private Devise deviseBuy;
        private CountryList countryBuy;
        private DateTime dateCreateOrderBuy;
        private TimeSpan validityTimePeriodeBuy;
        private TimeSpan validityAbsoluteTimeBuy;


        private Order orderTradeSell;
        private int orderQuantitySell;
        private int orderPriceSell;
        private Devise deviseSell;
        private CountryList countrySell;
        private DateTime dateCreateOrderSell;
        private TimeSpan validityTimePeriodeSell;
        private TimeSpan validityAbsoluteTimeSell;

        public Order OrderTradeBuy { get => orderTradeBuy; set => orderTradeBuy = value; }
        public int OrderQuantityBuy { get => orderQuantityBuy; set => orderQuantityBuy = value; }
        public int OrderPriceBuy { get => orderPriceBuy; set => orderPriceBuy = value; }
        public Devise DeviseBuy { get => deviseBuy; set => deviseBuy = value; }
        public CountryList CountryBuy { get => countryBuy; set => countryBuy = value; }
        public DateTime DateCreateOrderBuy { get => dateCreateOrderBuy; set => dateCreateOrderBuy = value; }
        public TimeSpan ValidityTimePeriodeBuy { get => validityTimePeriodeBuy; set => validityTimePeriodeBuy = value; }
        public TimeSpan ValidityAbsoluteTimeBuy { get => validityAbsoluteTimeBuy; set => validityAbsoluteTimeBuy = value; }

        public Order OrderTradeSell { get => orderTradeSell; set => orderTradeSell = value; }
        public int OrderQuantitySell { get => orderQuantitySell; set => orderQuantitySell = value; }
        public int OrderPriceSell { get => orderPriceSell; set => orderPriceSell = value; }
        public Devise DeviseSell { get => deviseSell; set => deviseSell = value; }
        public CountryList CountrySell { get => countrySell; set => countrySell = value; }
        public DateTime DateCreateOrderSell { get => dateCreateOrderSell; set => dateCreateOrderSell = value; }
        public TimeSpan ValidityTimePeriodeSell { get => validityTimePeriodeSell; set => validityTimePeriodeSell = value; }
        public TimeSpan ValidityAbsoluteTimeSell { get => validityAbsoluteTimeSell; set => validityAbsoluteTimeSell = value; }


        public TradeTable()
        {

            OrderTradeBuy = orderTradeBuy;
            OrderQuantityBuy = orderQuantityBuy;
            OrderPriceBuy = orderPriceBuy;
            DeviseBuy = deviseBuy;
            CountryBuy = countryBuy;
            DateCreateOrderBuy = dateCreateOrderBuy;
            ValidityTimePeriodeBuy = validityTimePeriodeBuy;
            ValidityAbsoluteTimeBuy = validityAbsoluteTimeBuy;

            OrderTradeSell = orderTradeSell;
            OrderQuantitySell = orderQuantitySell;
            OrderPriceSell = orderPriceSell;
            DeviseSell = deviseSell;
            CountrySell = countrySell;
            DateCreateOrderSell = dateCreateOrderSell;
            ValidityTimePeriodeSell = validityTimePeriodeSell;
            ValidityAbsoluteTimeSell = validityAbsoluteTimeSell;
        }



        // return a BuyTable by Ticker
        public static BuyTable GetBuyTableByTicker(string Ticker)
        {

            return BuyTables[Ticker];
        }



        // return a SellTable by Ticker
        public static SellTable GetSellTableByTicker(string Ticker)
        {

            return SellTables[Ticker];
        }






        // chek the validity of the Trade
        static bool IsTrade()
        {
            if (BuyTables.Equals(0) || SellTables.Equals(0)) return false;

            if (!BuyTables.Equals(0) && !SellTables.Equals(0))
            {
                return true;
            }
            return false;
        }

         // check the validity of the trade
        static bool IsValidTrade(string operation, Order order)
        {
            if (operation.Equals(Operation_type.BUY.ToString())
                || operation.Equals(Operation_type.SELL.ToString())
                || operation.Equals(Operation_type.MODIFY.ToString()))
            {
                //return true if arguments Order is valide
                if (order.IsValideOrder()) return true;
            }
            else if (operation.Equals(Operation_type.CANCEL.ToString()))
            {
                //return true if arguments Order CANCEL is valide
                if (order.IsValideOrder()) return true;
            }
            else if (operation.Equals(Operation_type.PRINT.ToString()))
            {
                //return true if arguments Order PRINT is valide
                if (order.IsValideOrder()) return true;
            }


            return false;
        }

        // return a minimum between two integers
        static int ReturnLeastNumber(int a, int b)
        {
            //int min = 0;
            if (a <= b) return a;
            else return b;

        }



        // SellTrade

        static void SellTrade(int idOrderSell,string Ticker)
        {


            // Get BuyTable by Ticker
            var buyTable = GetBuyTableByTicker(Ticker);
            // Sort buytable by OrderPrice
            var sortedBuyTable = buyTable.OrderByDescending(n => n.OrderPrice).ToList();


            int index = 0;
            foreach (var buyOrder in sortedBuyTable)
            {
                // Get an Order from SellTables
                var sellOrder = SellTables[Ticker].GetSellOrderByIdOrder(idOrderSell);

                if (sellOrder == null)
                { continue; }
                var sellOrderPrice = sellOrder.OrderPrice;
                var sellOrderQunt = sellOrder.OrderQuantity;
                var sellOrderType = sellOrder.OrderTrade;

                    if (sellOrderPrice > buyOrder.OrderPrice && index.Equals(0)) return;

                    var num_traded = ReturnLeastNumber(sellOrderQunt, buyOrder.OrderQuantity);

                //Update OrderQuantity
                buyOrder.OrderQuantity = num_traded;
                sellOrder.OrderQuantity = num_traded;
                int idOrderBuy =buyOrder.GetHashCode();
                ModifyTable(sellOrder, idOrderSell);
                ModifyTable(buyOrder, idOrderBuy);

                   if (sellOrderType.Equals(Order_type.IOC))
                    {
                        SellTables[Ticker].RemoveSellOrder(sellOrder);
                        
                        // break;
                    }
                    if (buyOrder.OrderTrade.Equals(Order_type.IOC))
                    {
                        BuyTables[Ticker].RemoveBuyOrder(buyOrder);
                        // break;
                    }

                    index++;

            }
            }




        // Modify Table
        static void ModifyTable(Order order, int idOrder)
        {

            if (order.OperationType.Equals(Operation_type.SELL))
            {

                if (SellTables[order.Ticker].Selltable.Contains(order))
                {


                    var temp = SellTables[order.Ticker].GetSellOrderByIdOrder(idOrder);

                    temp.OrderPrice = order.OrderPrice;
                    temp.OrderQuantity -= order.OrderQuantity;


                    if (temp.OrderQuantity <= 0)
                    {
                        temp.OrderQuantity = 0;
                        SellTables[order.Ticker].RemoveSellOrder(temp);
                    }
                    else
                    {
                        
                        SellTables[order.Ticker].RemoveSellOrder(order);
                        SellTables[order.Ticker].AddSellOrder(temp);
                    }
                }


            }
            if (BuyTables[order.Ticker].Buytable.Contains(order))
            {


                var temp = BuyTables[order.Ticker].GetBuyOrderByIdOrder(idOrder);

                temp.OrderPrice = order.OrderPrice;
                temp.OrderQuantity -= order.OrderQuantity;


                if (temp.OrderQuantity <= 0)
                {
                    temp.OrderQuantity = 0;
                    BuyTables[order.Ticker].RemoveBuyOrder(temp);
                }
                else
                {

                    BuyTables[order.Ticker].RemoveBuyOrder(order);
                    BuyTables[order.Ticker].AddBuyOrder(temp);
                }
            }
           
        }

    }

}
