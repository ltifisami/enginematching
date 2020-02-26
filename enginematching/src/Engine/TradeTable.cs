
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

            if (!BuyTables.Equals(0) && !SellTables.Equals(0))
            {
                return true;
            }
            return false;
        }

        // check the validity of the trade
        public static bool IsValidTrade(Operation_type operation_Type, Order order)
        {
            if (operation_Type == Operation_type.BUY
                || operation_Type == Operation_type.SELL
                || operation_Type == Operation_type.MODIFY)
            {
                //return true if arguments Order is valide
                if (order.IsValideOrder()) return true;
            }
            else if (operation_Type == Operation_type.CANCEL)
            {
                //return true if arguments Order CANCEL is valide
                if (order.IsValideOrder()) return true;
            }
            else if (operation_Type == Operation_type.PRINT)
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

        public static void SellTrade(int idOrderSell, string Ticker)
        {


            // Get BuyTable by Ticker
            var buyTable = BuyTable.GetBuyTableByTicker(Ticker);
            // Sort buytable by OrderPrice
            var sortedBuyTable = buyTable.OrderByDescending(n => n.OrderPrice).ToList();


            int index = 0;
            foreach (var buyOrder in sortedBuyTable)
            {
                // Get an Order from SellTables
                var sellOrder = SellTables[Ticker][idOrderSell];
                if (sellOrder == null)
                { continue; }
                var sellOrderPrice = sellOrder.OrderPrice;
                var sellOrderQunt = sellOrder.OrderQuantity;
                var sellOrderType = sellOrder.OrderTrade;

                if (sellOrderPrice > buyOrder.OrderPrice && index.Equals(0)) return;

                var num_traded = ReturnLeastNumber(sellOrderQunt, buyOrder.OrderQuantity);

                //Update OrderQuantity

                ModifyOrder(sellOrder, num_traded);
                ModifyOrder(buyOrder, num_traded);

                if (sellOrderType.Equals(Order_type.IOC))
                {
                    SellTables[Ticker].Remove(sellOrder);

                    // break;
                }
                if (buyOrder.OrderTrade.Equals(Order_type.IOC))
                {
                    BuyTables[Ticker].Remove(buyOrder);
                    // break;
                }

                index++;

            }
        }









        // Modify Table
        public static void ModifyOrder(Order order, int numTraded)
        {

            if (order.OperationType == Operation_type.SELL)
            {
                //(currentSellOrderID, operation_type.SELL, currentSellOrderPrice, num_traded, currentSellOrderType);
                if (SellTable.Selltable.Contains(order))
                {


                    var temp = order.OrderQuantity - numTraded;
                   



                    if (temp <= 0)
                    {
                        SellTable.Selltable.Remove(order);
                    }
                    else
                    {

                        order.OrderQuantity = order.OrderQuantity - numTraded;
                    }


                }
                if (BuyTable.Buytable.Contains(order))
                {

                    var temp = order.OrderQuantity - numTraded;
                    if (temp<= 0)
                    {
                        BuyTable.Buytable.Remove(order);
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
