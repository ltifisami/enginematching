using System;
using System.Collections.Generic;
using System.Linq;
using static Engine.CurrencyRates;

namespace Engine
{
    public class Matching : IMatching
    {

        public  Dictionary<string, IOrder> printBuyOrderTable = new Dictionary<string, IOrder>();
        public  Dictionary<string, IOrder> printSellOrderTable = new Dictionary<string, IOrder>();
        public  static List<TradeTable> Tradetable = new List<TradeTable>();



        // Sell trade
        public void SellTrade()
        {
            foreach (var kvp in SellTable.SellTables.Keys)
            {
                // Get BuyTables and SellTables by Ticker :
                var buyTable = BuyTable.BuyTables[kvp];
                var sellTable = SellTable.SellTables[kvp];

               // Sort buytable by OrderPrice
               var sortedBuyTable = buyTable.OrderByDescending(n => n.OrderPrice).ToList();


            int index = 0;
                foreach (var buyOrder in sortedBuyTable)
                {

                    {
                        foreach (var sellOrder in sellTable)
                        {


                            if (sellOrder == null)
                            { continue; }

                           // Convert the prices to Dollar
                            var sellOrderPriceUSD = CovertToDollar(sellOrder);
                            var buyOrderUSD = CovertToDollar(buyOrder);


                            if (sellOrderPriceUSD > buyOrderUSD && index.Equals(0)) return;

                            var num_traded = ReturnLeastNumber(sellOrder.OrderQuantity, buyOrder.OrderQuantity);

                            // Create a TradeTable
                            TradeTable.AddTradeTable(buyOrder, sellOrder, num_traded);

                            // Modify the Statue of the Order traded
                            OrderBook.OrderBookCollection[sellOrder.OrderId].Statue = Statue.MATCHED;
                            OrderBook.OrderBookCollection[buyOrder.OrderId].Statue = Statue.MATCHED;

                            //Update OrderQuantity
                            ModifyOrder(sellOrder, num_traded); ;
                            ModifyOrder(buyOrder, num_traded);

                            if (sellOrder.OrderTrade.Equals(Order_type.IOC))
                            {
                                SellTable.SellTables[kvp].Remove(sellOrder);

                                // break;
                            }
                            if (buyOrder.OrderTrade.Equals(Order_type.IOC))
                            {
                                BuyTable.BuyTables[kvp].Remove(buyOrder);

                                // break;
                            }

                            index++;
                        }
                    }
                }
            }

            foreach (var kvp in BuyTable.BuyTables.Keys)
            {
                foreach (var kvp1 in BuyTable.BuyTables[kvp])
                {
                    if (kvp1.OrderTrade == Order_type.IOC)
                    {
                        BuyTable.Buytable.Remove(kvp1);
                    }
                }
            }

            PrintOperation();
        }

        // Chek the validity of the Trade
        public  bool IsTrade()
        {
            if (BuyTable.BuyTables.Equals(0) || SellTable.SellTables.Equals(0)) return false;
            int i = 0;
            foreach (var key in BuyTable.BuyTables.Keys)
            {
                if (SellTable.SellTables.ContainsKey(key)) i++;
            }
            if (!BuyTable.BuyTables.Equals(0) && !SellTable.SellTables.Equals(0) && i != 0) return true;

            return false;
        }

        // Chek the validity  of Order 
        public  bool IsValidOrder(string operation, string[] operation_statement_array)
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
        public  int ReturnLeastNumber(int a, int b)
        {
            //int min = 0;
            if (a <= b) return a;
            else return b;

        }
        // Modify Table
        public  void ModifyOrder(IOrder order, int numTraded)
        {

            if (order.OperationType == Operation_type.SELL)
            {
                //(currentSellOrderID, operation_type.SELL, currentSellOrderPrice, num_traded, currentSellOrderType);
                if (SellTable.SellTables[order.Ticker].Contains(order))
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

            }
            if (order.OperationType == Operation_type.BUY)
            {

                if (BuyTable.BuyTables[order.Ticker].Contains(order))
                {
                    var temp = order.OrderQuantity - numTraded;
                    if (temp <= 0)
                    {  BuyTable.Buytable.Remove(order); }
                    else
                    {
                       order.OrderQuantity = order.OrderQuantity - numTraded;
                    }
                }
            }
        }

        public void PrintOperation()
        {
            //PRINT Operation logic
            //Printing Sell operations
            GeneratePrintTable();

            Console.WriteLine("SELL:");
            foreach (var kvp1 in printSellOrderTable.Values.Reverse())
            {
                //Console.WriteLine("OrderID GFD 1000 10 EUR ABCDEFGH1234 Germany MM-DD-yyyy h:mm:tt  MM-DD-yyyy h:mm:tt ");
                Console.WriteLine(kvp1.OrderId + " " + kvp1.OrderTrade + " " + kvp1.OrderPrice + " " + kvp1.OrderQuantity + " " + kvp1.Devise + " " + kvp1.Ticker + " " + kvp1.Country + " " + kvp1.DateCreateOrder + " " + kvp1.DateEndOrder);
            }
            //Printing BUY operations
            Console.WriteLine("BUY:");
            foreach (var kvp1 in printBuyOrderTable.Values.Reverse())
            {
                //Console.WriteLine("OrderID GFD 1000 10 EUR ABCDEFGH1234 Germany MM-DD-yyyy h:mm:tt  MM-DD-yyyy h:mm:tt ");
                Console.WriteLine(kvp1.OrderId + " " + kvp1.OrderTrade + " " + kvp1.OrderPrice + " " + kvp1.OrderQuantity + " " + kvp1.Devise + " " + kvp1.Ticker + " " + kvp1.Country + " " + kvp1.DateCreateOrder + " " + kvp1.DateEndOrder);
            }

        }

        public void GeneratePrintTable()
        {
            foreach (var kvp1 in SellTable.Selltable)
            {
                try
                {
                    printSellOrderTable.Add(kvp1.OrderId, kvp1);
                }
                catch
                {
                    printSellOrderTable[kvp1.OrderId].OrderPrice += kvp1.OrderQuantity;
                }
            }

            foreach (var kvp1 in BuyTable.Buytable)
            {
                try
                {
                    printBuyOrderTable.Add(kvp1.OrderId, kvp1);
                }
                catch
                {

                    printBuyOrderTable[kvp1.OrderId].OrderPrice += kvp1.OrderQuantity;
                }
            }

        }



        // Convert a cuurent Devise to Dollar Devise
        public decimal CovertToDollar(IOrder order)
        {

            OpenExchange openExchange = new OpenExchange();
            CurrencyRates cc = openExchange.GetCurrencyRates();
            string _currentDevise = order.ConvertDeviseToString(order);
            decimal dollarDevise = cc.Rates[_currentDevise] * order.OrderPrice;
            return dollarDevise;
        }

        public void WriteTradeTable()
        {
            foreach (var _tradeTable in Tradetable)
            {

                Console.WriteLine("TRADE {0} {1} {2} {3} {4} {5} {6} {7} {8} ", _tradeTable.BuyOrderId, _tradeTable.OrderPriceBuy,
                    _tradeTable.DeviseBuy, _tradeTable.CountryBuy, _tradeTable.OrderQuantityTraded, _tradeTable.SellOrderId,
                    _tradeTable.OrderPriceSell, _tradeTable.DeviseSell, _tradeTable.CountrySell);
            }

        }

        public void WriteOrderBookCollection()
        {
            foreach (var order in OrderBook.OrderBookCollection.Values)
            {

                Console.WriteLine("Order {0} {1} {2} {3} {4} {5} {6} {7} {8} ", order.OrderId, order.OperationType, order.OrderTrade, order.OrderPrice, order.OrderQuantity, order.Devise, order.Country, order.DateCreateOrder, order.DateEndOrder);
            }

        }

        public void ModifyOrder(string [] orderArray)
        {
            if (orderArray[2] == "SELL")
            {

                if (!SellTable.Selltable[Convert.ToInt32(orderArray[1])].Equals(null))
                {

                    string _dateEnd = String.Concat(orderArray[8], " ", orderArray[9]);
                    DateTime dateTimeEnd = Convert.ToDateTime(_dateEnd);

                    if (DateTime.Compare(dateTimeEnd, SellTable.Selltable[Convert.ToInt32(orderArray[1])].DateCreateOrder) > 0)
                    {
                        // Modify  Selltable 
                        SellTable.Selltable[Convert.ToInt32(orderArray[1])].OrderPrice = Convert.ToInt32(orderArray[3]);
                        SellTable.Selltable[Convert.ToInt32(orderArray[1])].OrderQuantity = Convert.ToInt32(orderArray[4]);
                        SellTable.Selltable[Convert.ToInt32(orderArray[1])].Devise = SellTable.Selltable[Convert.ToInt32(orderArray[1])].GetDevise(orderArray[5]);
                        SellTable.Selltable[Convert.ToInt32(orderArray[1])].Ticker = Convert.ToString(orderArray[6]);
                        SellTable.Selltable[Convert.ToInt32(orderArray[1])].Country = Convert.ToString(orderArray[7]);
                        SellTable.Selltable[Convert.ToInt32(orderArray[1])].DateEndOrder = dateTimeEnd;

                        // Modify  OrderBookCollection
                        OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])].OrderPrice = Convert.ToInt32(orderArray[3]);
                        OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])].OrderQuantity = Convert.ToInt32(orderArray[4]);
                        OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])].Devise = SellTable.Selltable[Convert.ToInt32(orderArray[1])].GetDevise(orderArray[5]);
                        OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])].Ticker = Convert.ToString(orderArray[6]);
                        OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])].Country = Convert.ToString(orderArray[7]);
                        OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])].DateEndOrder = dateTimeEnd;

                    }

                }

            }
            if (orderArray[2] == "BUY")
            {
                if (!BuyTable.Buytable[Convert.ToInt32(orderArray[1])].Equals(null))
                {
                    var _dateEnd = String.Concat(orderArray[8], " ", orderArray[9]);
                    var dateTimeEnd = Convert.ToDateTime(_dateEnd);

                    if (DateTime.Compare(dateTimeEnd, BuyTable.Buytable[Convert.ToInt32(orderArray[1])].DateCreateOrder) > 0)
                    {
                        // Modify Buytable 

                        BuyTable.Buytable[Convert.ToInt32(orderArray[1])].OrderPrice = Convert.ToInt32(orderArray[3]);
                        BuyTable.Buytable[Convert.ToInt32(orderArray[1])].OrderQuantity = Convert.ToInt32(orderArray[4]);
                        BuyTable.Buytable[Convert.ToInt32(orderArray[1])].Devise = BuyTable.Buytable[Convert.ToInt32(orderArray[1])].GetDevise(orderArray[5]);
                        BuyTable.Buytable[Convert.ToInt32(orderArray[1])].Ticker = Convert.ToString(orderArray[6]);
                        BuyTable.Buytable[Convert.ToInt32(orderArray[1])].Country = Convert.ToString(orderArray[7]);
                        BuyTable.Buytable[Convert.ToInt32(orderArray[1])].DateEndOrder = dateTimeEnd;

                        // Modify  OrderBookCollection
                        OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])].OrderPrice = Convert.ToInt32(orderArray[3]);
                        OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])].OrderQuantity = Convert.ToInt32(orderArray[4]);
                        OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])].Devise = BuyTable.Buytable[Convert.ToInt32(orderArray[1])].GetDevise(orderArray[5]);
                        OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])].Ticker = Convert.ToString(orderArray[6]);
                        OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])].Country = Convert.ToString(orderArray[7]);
                        OrderBook.OrderBookCollection[Convert.ToString(orderArray[1])].DateEndOrder = dateTimeEnd;
                    }
                }
            }
        }
    }
}
