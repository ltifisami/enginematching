


using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class OrderBook
    {

        // Generic Collection contains all the Order
        public IDictionary<string, Order> OrderBookCollection;
        public static List<Order> Buytable = new List<Order>();
        public static Dictionary<string, List<Order>> BuyTables = new Dictionary<string, List<Order>>();
        public static List<Order> Selltable = new List<Order>();
        public static Dictionary<string, List<Order>> SellTables = new Dictionary<string, List<Order>>();
        public static Dictionary<int, int> printBuyOrderTable = new Dictionary<int, int>();
        public static Dictionary<int, int> printSellOrderTable = new Dictionary<int, int>();



        //Constructor 
        public OrderBook(IDictionary<string, Order> OrderBookCollection)
        {
            this.OrderBookCollection = OrderBookCollection;
        }

        // methode to add a new Order in the order book collection
        public void AddOrder(string Ticker, Order order)
        {
            OrderBookCollection.Add(Ticker, order);
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
            foreach (var kvp1 in printSellOrderTable.Reverse())
            {

                //Console.WriteLine("Order ID = {0}", kvp1.Key);
                Console.WriteLine(kvp1.Key + " " + kvp1.Value);
            }
            //Printing BUY operations
            Console.WriteLine("BUY:");
            foreach (var kvp1 in printBuyOrderTable.Reverse())
            {
                //Console.WriteLine("Order ID = {0}", kvp1.Key);
                Console.WriteLine(kvp1.Key + " " + kvp1.Value);
            }



        }




        static void GeneratePrintTable()
        {
            foreach (var kvp1 in Selltable)
            {
                try
                {
                    printSellOrderTable.Add(kvp1.OrderPrice, kvp1.OrderQuantity);
                }
                catch
                {
                    printSellOrderTable[kvp1.OrderPrice] += kvp1.OrderQuantity;
                }
            }

            foreach (var kvp1 in Buytable)
            {
                try
                {
                    printBuyOrderTable.Add(kvp1.OrderPrice, kvp1.OrderQuantity);
                }
                catch
                {
                    printBuyOrderTable[kvp1.OrderPrice] += kvp1.OrderQuantity;
                }
            }

        }









        public void CreateOrderBook()
        {

            BuyTable _BuyTable = new BuyTable();
            SellTable _SellTable = new SellTable();





            // Enter your code here. Read input using Console.ReadLine. Print output using Console.WriteLine. 
            // Your class should be named Solution */
            string[] stdInputArgumentsArray = new string[] { };



            //Reading the standard input arguments and spilt them based on spaces

            //Exmaple :  //Exmaple order1 : "ABCDEFGH1234" BUY GFD 1000 10 EUR Germany MM/dd/yyyy h:mm tt 02.00:00:00 0.00:00:1000  0order1

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

                Order _Order = new Order();
                // Create an Order 
                _Order = Order.CreateOrder(stdInputArgumentsArray);




                //Checks if the Trade statement is right
                if (TradeTable.IsValidTrade(_Order.OperationType, _Order))
                {
                    switch (_Order.OperationType)
                    {
                        case Operation_type.BUY:
                            {
                                //BUY Operation logic
                                try
                                {

                                    TradeTable.AddBuyOrderInBuyTables(Buytable, _Order);
                                }
                                catch
                                {
                                    Console.WriteLine("Error?");
                                }
                                break;
                            }
                        case Operation_type.SELL:
                            {
                                //SELL Operation logic
                                try
                                {
                                    TradeTable.AddSellOrderInSellTables(Selltable, _Order);
                                }
                                catch
                                {
                                    Console.WriteLine("Repeated?");
                                }
                                break;
                            }
                            /*
                        case Operation_type.CANCEL:
                            {
                                //CANCEL Operation logic
                                //Removing Sell and BUY tabel entry
                                if (Selltable.Contains(_Order))
                                {
                                    Selltable.Remove(_Order);

                                }
                                else if (Buytable.Contains(_Order))
                                {
                                    Buytable.Remove(_Order);
                                }

                                break;
                            }
                            */
                            /*
                       
                     case Operation_type.MODIFY:
                         {

                             //MODIFY Operation logic
                             if (stdInputArgumentsArray[2] )
                             {
                                 if (sellTable.ContainsKey(stdInputArgumentsArray[1]))
                                 {
                                     var temp = sellTable[stdInputArgumentsArray[1]];
                                     if (temp.order_trade.Equals(order_type.IOC) || temp.order_trade.Equals(order_type.INV)) break;
                                     order_table _orderTable = new order_table();
                                     _orderTable.order_price = Convert.ToInt32(stdInputArgumentsArray[3]);
                                     _orderTable.order_quantity = Convert.ToInt32(stdInputArgumentsArray[4]);
                                     _orderTable.order_trade = temp.order_trade;

                                     sellTable.Remove(stdInputArgumentsArray[1]);
                                     sellTable.Add(stdInputArgumentsArray[1], _orderTable);

                                 }
                             }
                             if (stdInputArgumentsArray[2].Equals(BUY_LABEL))
                             {
                                 if (buyTable.ContainsKey(stdInputArgumentsArray[1]))
                                 {
                                     var temp = buyTable[stdInputArgumentsArray[1]];
                                     if (temp.order_trade.Equals(order_type.IOC) || temp.order_trade.Equals(order_type.INV)) break;
                                     order_table _orderTable = new order_table();
                                     _orderTable.order_price = Convert.ToInt32(stdInputArgumentsArray[3]);
                                     _orderTable.order_quantity = Convert.ToInt32(stdInputArgumentsArray[4]);
                                     _orderTable.order_trade = temp.order_trade;

                                     buyTable.Remove(stdInputArgumentsArray[1]);

                                     buyTable.Add(stdInputArgumentsArray[1], _orderTable);

                                     //buyTable.Add(stdInputArgumentsArray[1], _orderTable);
                                 }
                             }
                             break;

                         }
                         */

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
                    //Console.Write("Here");
                    //tempSellTable = sellTable;
                    // try
                    {
                        var totalNumberOfSellOrders = Selltable.Count;
                        //llTable.
                        int indexSellTable = 0;
                        // var tempSellTable = sellTable;
                        while (indexSellTable < totalNumberOfSellOrders)
                        {
                            foreach (var kvp1 in Selltable)
                            {


                                TradeTable.SellTrade(SellTable.GetSellOrderId(kvp1), kvp1.Ticker);

                            }
                            indexSellTable++;
                        }
                        foreach (var kvp1 in Selltable)
                        {
                            if (kvp1.OrderTrade == Order_type.IOC)
                            {
                                Selltable.Remove(kvp1);
                            }
                        }

                        foreach (var kvp1 in Buytable)
                        {
                            if (kvp1.OrderTrade == Order_type.IOC)
                            {
                                Buytable.Remove(kvp1);
                            }
                        }
                    }
                    // catch { }
                     PrintOperation();
                }

                //check for SELL AND BUY Tables for suitable trades.
                else if (!TradeTable.IsTrade() && stdInputArgumentsArray[0] == "PRINT")
                {
                     PrintOperation();
                }
                else if (TradeTable.IsTrade())
                {
                    var totalNumberOfSellOrders = Selltable.Count;
                    //llTable.
                    int indexSellTable = 0;
                    // var tempSellTable = sellTable;
                    while (indexSellTable < totalNumberOfSellOrders)
                    {
                        foreach (var kvp1 in Selltable)
                        {
                            TradeTable.SellTrade(SellTable.GetSellOrderId(kvp1), kvp1.Ticker);

                        }
                        indexSellTable++;

                    }

                    foreach (var kvp1 in Selltable)
                    {
                        if (kvp1.OrderTrade == Order_type.IOC)
                        {
                            Selltable.Remove(kvp1);
                        }
                    }

                    foreach (var kvp1 in Buytable)
                    {
                        if (kvp1.OrderTrade == Order_type.IOC)
                        {
                            Buytable.Remove(kvp1);
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


    


    



   








