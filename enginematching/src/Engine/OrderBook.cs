


using System;
using System.Collections.Generic;
using System.Linq;
using static Engine.CurrencyRates;

namespace Engine
{
    public class OrderBook
    {

        public static Dictionary<string, IOrder> OrderBookCollection = new Dictionary<string, IOrder>();
        public static List<TradeTable> Tradetable = new List<TradeTable>();
        public static Dictionary<string, IOrder> printBuyOrderTable = new Dictionary<string, IOrder>();
        public static Dictionary<string, IOrder> printSellOrderTable = new Dictionary<string, IOrder>();





        public OrderBook()
        {
        }


        public static void AddOrder(string _OrderId, Order _order)
        {
            if (!OrderBookCollection.ContainsKey(_OrderId))
            {
                _order.OrderId = _OrderId;
                OrderBookCollection.Add(_OrderId, _order);
            }
        }

        //methode return an order in the order book collection by Tiker
        public Order GetOrderbyTicker(string Ticker, IDictionary<string, Order> OrderBookCollection)
        {
            Order ot = OrderBookCollection[Ticker];
            return ot;
        }



        static void PrintOperation()
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




        static void GeneratePrintTable()
        {
            foreach (var kvp1 in TradeTable.Selltable)
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

            foreach (var kvp1 in TradeTable.Buytable)
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
            foreach (var order in OrderBookCollection.Values)
            {

                Console.WriteLine("Order {0} {1} {2} {3} {4} {5} {6} {7} {8} ", order.OrderId, order.OperationType, order.OrderTrade, order.OrderPrice, order.OrderQuantity, order.Devise, order.Country, order.DateCreateOrder, order.DateEndOrder);
            }

        }

        // Convert a cuurent Devise to Dollar Devise
        public static decimal CovertToDollar(IOrder order)
        {

            OpenExchange openExchange = new OpenExchange();
            CurrencyRates cc = openExchange.GetCurrencyRates();
            string _currentDevise = order.ConvertDeviseToString(order);
            decimal dollarDevise = cc.Rates[_currentDevise] * order.OrderPrice;
            return dollarDevise;
        }

        // SellTrade

        public static void SellTrade(string Ticker)
        {
            // Get BuyTable by Ticker
            var buyTable = TradeTable.BuyTables[Ticker];
            var sellTable = TradeTable.SellTables[Ticker];

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


                        var sellOrderPrice = sellOrder.OrderPrice;
                        var sellOrderQunt = sellOrder.OrderQuantity;
                        var sellOrderType = sellOrder.OrderTrade;

                        var sellOrderPriceUSD = OrderBook.CovertToDollar(sellOrder);
                        var buyOrderUSD = OrderBook.CovertToDollar(buyOrder);

                        if (sellOrderPriceUSD > buyOrderUSD && index.Equals(0)) return;
                        var num_traded = TradeTable.ReturnLeastNumber(sellOrderQunt, buyOrder.OrderQuantity);

                        // create a TradeTable
                        TradeTable _tradeTable = new TradeTable
                        {
                            BuyOrderId = buyOrder.OrderId,
                            OrderPriceBuy = buyOrder.OrderPrice,
                            DeviseBuy = buyOrder.Devise,
                            CountryBuy = buyOrder.Country,
                            OrderQuantityTraded = num_traded,
                            SellOrderId = sellOrder.OrderId,
                            OrderPriceSell = sellOrderPrice,
                            DeviseSell = sellOrder.Devise,
                            CountrySell = sellOrder.Country
                        };

                        // Add the _tradeTable in Tradetable 


                        Tradetable.Add(_tradeTable);


                        //Update OrderQuantity


                        TradeTable.ModifyOrder(sellOrder, num_traded); ;
                        TradeTable.ModifyOrder(buyOrder, num_traded);
                        if (sellOrderType.Equals(Order_type.IOC))
                        {
                            TradeTable.SellTables[Ticker].Remove(sellOrder);

                            // break;
                        }
                        if (buyOrder.OrderTrade.Equals(Order_type.IOC))
                        {
                            TradeTable.BuyTables[Ticker].Remove(buyOrder);

                            // break;
                        }

                        index++;
                    }
                }

            }



        }

        public void CreateOrderBook()
        {



            string[] stdInputArgumentsArray = new string[] { };

            //Reading the standard input arguments and spilt them based on spaces
            Console.WriteLine(" Enter an Order");
            Console.WriteLine("OperationType OrderTrade Price Quantity Devise Ticker Country MM-DD-yyyy h:mm:tt orderId");

            //All the spilt argemtns are saved to an array named stdInputArgumentsArray

            //Console.Read();
            List<string> stdInput = new List<string>();

            string currentLine = " ";

            while ((currentLine = Console.ReadLine()) != null && currentLine != "")
            {
                stdInput.Add(currentLine);
            }


            foreach (var line in stdInput)
            {
                stdInputArgumentsArray = line.Split(null);

                //Checks if the Trade statement is right
                if (TradeTable.IsValidTrade(stdInputArgumentsArray[0], stdInputArgumentsArray))
                {

                    switch (stdInputArgumentsArray[0])
                    {

                        case "BUY":
                            {
                                //BUY Operation logic
                                try
                                {
                                    Order _Order = new Order();
                                    _Order = _Order.CreateOrder(stdInputArgumentsArray);
                                    OrderBookCollection.Add(Convert.ToString(stdInputArgumentsArray[9]), _Order);
                                    TradeTable.Buytable.Add(_Order);
                                    TradeTable.AddBuyOrderInBuyTables(_Order);

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
                                    _Order = _Order.CreateOrder(stdInputArgumentsArray);
                                    OrderBook.AddOrder(stdInputArgumentsArray[9], _Order);
                                    TradeTable.Selltable.Add(_Order);
                                    TradeTable.AddSellOrderInSellTables(_Order);
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

                                if (TradeTable.Selltable.Contains(OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])]))
                                {
                                    TradeTable.Selltable.Remove(OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])]);
                                    OrderBookCollection.Remove(Convert.ToString(stdInputArgumentsArray[1]));

                                }
                                else if (TradeTable.Buytable.Contains(OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])]))
                                {
                                    TradeTable.Buytable.Remove(OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])])  ;
                                    OrderBookCollection.Remove(Convert.ToString(stdInputArgumentsArray[1]));
                                }

                                break;
                            }



                        case "MODIFY":
                            {

                                //MODIFY Operation logic
                                // MODIFY orderId OperationType Price Quantity Devise Ticker Country MM-DD-yyyy h:mm:tt 
                                if (stdInputArgumentsArray[2] == "SELL")
                                {

                                    if (!TradeTable.Selltable[Convert.ToInt32(stdInputArgumentsArray[1])].Equals(null))
                                    {

                                        string _dateEnd = String.Concat(stdInputArgumentsArray[8], " ", stdInputArgumentsArray[9]);
                                        DateTime dateTimeEnd = Convert.ToDateTime(_dateEnd);

                                        if (DateTime.Compare(dateTimeEnd, TradeTable.Selltable[Convert.ToInt32(stdInputArgumentsArray[1])].DateCreateOrder) > 0)
                                        {
                                            // Modify  Selltable 
                                            TradeTable.Selltable[Convert.ToInt32(stdInputArgumentsArray[1])].OrderPrice = Convert.ToInt32(stdInputArgumentsArray[3]);
                                            TradeTable.Selltable[Convert.ToInt32(stdInputArgumentsArray[1])].OrderQuantity = Convert.ToInt32(stdInputArgumentsArray[4]);
                                            TradeTable.Selltable[Convert.ToInt32(stdInputArgumentsArray[1])].Devise = TradeTable.Selltable[Convert.ToInt32(stdInputArgumentsArray[1])].GetDevise(stdInputArgumentsArray[5]);
                                            TradeTable.Selltable[Convert.ToInt32(stdInputArgumentsArray[1])].Ticker = Convert.ToString(stdInputArgumentsArray[6]);
                                            TradeTable.Selltable[Convert.ToInt32(stdInputArgumentsArray[1])].Country = Convert.ToString(stdInputArgumentsArray[7]);
                                            TradeTable.Selltable[Convert.ToInt32(stdInputArgumentsArray[1])].DateEndOrder = dateTimeEnd;

                                            // Modify  OrderBookCollection
                                            OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])].OrderPrice = Convert.ToInt32(stdInputArgumentsArray[3]);
                                            OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])].OrderQuantity = Convert.ToInt32(stdInputArgumentsArray[4]);
                                            OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])].Devise = TradeTable.Selltable[Convert.ToInt32(stdInputArgumentsArray[1])].GetDevise(stdInputArgumentsArray[5]);
                                            OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])].Ticker = Convert.ToString(stdInputArgumentsArray[6]);
                                            OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])].Country = Convert.ToString(stdInputArgumentsArray[7]);
                                            OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])].DateEndOrder = dateTimeEnd;

                                        }

                                    }

                                }
                                if (stdInputArgumentsArray[2] == "BUY")
                                {
                                    if (!TradeTable.Buytable[Convert.ToInt32(stdInputArgumentsArray[1])].Equals(null))
                                    {
                                        var _dateEnd = String.Concat(stdInputArgumentsArray[8], " ", stdInputArgumentsArray[9]);
                                        var dateTimeEnd = Convert.ToDateTime(_dateEnd);

                                        if (DateTime.Compare(dateTimeEnd, TradeTable.Buytable[Convert.ToInt32(stdInputArgumentsArray[1])].DateCreateOrder) > 0)
                                        {
                                            // Modify Buytable 

                                            TradeTable.Buytable[Convert.ToInt32(stdInputArgumentsArray[1])].OrderPrice = Convert.ToInt32(stdInputArgumentsArray[3]);
                                            TradeTable.Buytable[Convert.ToInt32(stdInputArgumentsArray[1])].OrderQuantity = Convert.ToInt32(stdInputArgumentsArray[4]);
                                            TradeTable.Buytable[Convert.ToInt32(stdInputArgumentsArray[1])].Devise = TradeTable.Buytable[Convert.ToInt32(stdInputArgumentsArray[1])].GetDevise(stdInputArgumentsArray[5]);
                                            TradeTable.Buytable[Convert.ToInt32(stdInputArgumentsArray[1])].Ticker = Convert.ToString(stdInputArgumentsArray[6]);
                                            TradeTable.Buytable[Convert.ToInt32(stdInputArgumentsArray[1])].Country = Convert.ToString(stdInputArgumentsArray[7]);
                                            TradeTable.Buytable[Convert.ToInt32(stdInputArgumentsArray[1])].DateEndOrder = dateTimeEnd;

                                            // Modify  OrderBookCollection
                                            OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])].OrderPrice = Convert.ToInt32(stdInputArgumentsArray[3]);
                                            OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])].OrderQuantity = Convert.ToInt32(stdInputArgumentsArray[4]);
                                            OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])].Devise = TradeTable.Buytable[Convert.ToInt32(stdInputArgumentsArray[1])].GetDevise(stdInputArgumentsArray[5]);
                                            OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])].Ticker = Convert.ToString(stdInputArgumentsArray[6]);
                                            OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])].Country = Convert.ToString(stdInputArgumentsArray[7]);
                                            OrderBookCollection[Convert.ToString(stdInputArgumentsArray[1])].DateEndOrder = dateTimeEnd;
                                        }
                                    }
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
                if (stdInputArgumentsArray[0] == "PRINT" && TradeTable.IsTrade())
                {
                    foreach (var kvp in TradeTable.SellTables.Keys)
                    {
                        SellTrade(kvp);
                    }


                    foreach (var kvp in TradeTable.SellTables.Keys)
                    {
                        foreach (var kvp1 in TradeTable.SellTables[kvp])
                        {
                            if (kvp1.OrderTrade == Order_type.IOC)
                            {
                                TradeTable.Selltable.Remove(kvp1);
                            }
                        }
                    }


                    foreach (var kvp in TradeTable.BuyTables.Keys)
                    {
                        foreach (var kvp1 in TradeTable.BuyTables[kvp])
                        {
                            if (kvp1.OrderTrade == Order_type.IOC)
                            {
                                TradeTable.Buytable.Remove(kvp1);
                            }
                        }
                    }

                    PrintOperation();
                }

                //check for SELL AND BUY Tables for suitable trades.
                else if (!TradeTable.IsTrade() && stdInputArgumentsArray[0] == "PRINT")
                {
                    PrintOperation();
                }

                else if (TradeTable.IsTrade())
                {
                    foreach (var kvp in TradeTable.SellTables.Keys)
                    {
                        SellTrade(kvp);
                    }


                    foreach (var kvp in TradeTable.SellTables.Keys)
                    {
                        foreach (var kvp1 in TradeTable.SellTables[kvp])
                        {
                            if (kvp1.OrderTrade == Order_type.IOC)
                            {
                                TradeTable.Selltable.Remove(kvp1);
                            }
                        }
                    }


                    foreach (var kvp in TradeTable.BuyTables.Keys)
                    {
                        foreach (var kvp1 in TradeTable.BuyTables[kvp])
                        {
                            if (kvp1.OrderTrade == Order_type.IOC)
                            {
                                TradeTable.Buytable.Remove(kvp1);
                            }
                        }
                    }

                }
                Console.ReadKey();
            }
            catch
            { Console.ReadKey(); }
            Console.ReadKey();
        }

    }
}


















