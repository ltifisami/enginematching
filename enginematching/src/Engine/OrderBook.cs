


using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class OrderBook
    {

        // Generic Collection contains all the Order
        public static Dictionary<string, Order> OrderBookCollection = new Dictionary<string, Order>();
         public static List<Order> Buytable = new List<Order>();
         public static List<Order> Selltable = new List<Order>();
        public static List<TradeTable> Tradetable = new List<TradeTable>();
        public static Dictionary<int, int> printBuyOrderTable = new Dictionary<int, int>();
        public static Dictionary<int, int> printSellOrderTable = new Dictionary<int, int>();
       
            

       

        public OrderBook()
        {
        }


        public static void AddOrder(string _OrderId, Order _order)
        {
            if(!OrderBookCollection.ContainsKey(_OrderId))
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
            foreach (var kvp1 in printSellOrderTable.Reverse())
            {

                //Console.WriteLine("Order ID = {0}", kvp1.Key);
                Console.WriteLine(kvp1.Key + " " + kvp1.Value );
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


        // SellTrade

        public static void SellTrade(Order sellOrder, string Ticker)
        {
            // Get BuyTable by Ticker
            var buyTable = TradeTable.BuyTables[Ticker];
            var sellTable = TradeTable.SellTables[Ticker];
            // Sort buytable by OrderPrice
            var sortedBuyTable = buyTable.OrderByDescending(n => n.OrderPrice).ToList();


            int index = 0;
            foreach (var buyOrder in sortedBuyTable)
            {

                if (sellOrder == null)
                { continue; }

                var sellOrderPrice = sellOrder.OrderPrice;
                var sellOrderQunt = sellOrder.OrderQuantity;
                var sellOrderType = sellOrder.OrderTrade;
                if (sellOrderPrice > buyOrder.OrderPrice && index.Equals(0)) return;
                var num_traded = TradeTable.ReturnLeastNumber(sellOrderQunt, buyOrder.OrderQuantity);

                // create a TradeTable
                TradeTable _tradeTable = new TradeTable();

                _tradeTable.BuyOrderId = buyOrder.OrderId;
                _tradeTable.OrderPriceBuy = buyOrder.OrderPrice;
                _tradeTable.DeviseBuy = buyOrder.Devise;
                _tradeTable.CountryBuy = buyOrder.Country;
                _tradeTable.OrderQuantityTraded = num_traded;
                _tradeTable.SellOrderId = sellOrder.OrderId;
                _tradeTable.OrderPriceSell = sellOrderPrice;
                _tradeTable.DeviseSell = sellOrder.Devise;
                _tradeTable.CountrySell = sellOrder.Country;

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







        public void CreateOrderBook()
        {

            BuyTable _BuyTable = new BuyTable();
            SellTable _SellTable = new SellTable();

            // Enter your code here. Read input using Console.ReadLine. Print output using Console.WriteLine. 
            // Your class should be named Solution */
            string[] stdInputArgumentsArray = new string[] { };

            //Reading the standard input arguments and spilt them based on spaces
            Console.WriteLine(" Enter an Order");
            Console.WriteLine("Exmaple order1 :  BUY GFD 1000 10 EUR ABCDEFGH1234 Germany MM/dd/yyyy h:mm tt 02.00:00:00 0.00:00:1000 order1");
            //Exmaple :  //Exmaple order1 : "ABCDEFGH1234" BUY GFD 1000 10 EUR Germany MM/dd/yyyy h:mm tt 02.00:00:00 0.00:00:1000  0order1

            //All the spilt argemtns are saved to an array named stdInputArgumentsArray

            //Console.Read();
            List<string> stdInput = new List<string>();

            string currentLine = " ";

            while ((currentLine = Console.ReadLine()) != null && currentLine != "" )
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
                                    _Order = Order.CreateOrder(stdInputArgumentsArray);
                                    OrderBookCollection.Add(Convert.ToString(stdInputArgumentsArray[10]), _Order);
                                    TradeTable.AddBuyOrderInBuyTables(Buytable, _Order);

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
                                    _Order = Order.CreateOrder(stdInputArgumentsArray);
                                    OrderBook.AddOrder(stdInputArgumentsArray[10], _Order);
                                    TradeTable.AddSellOrderInSellTables(Selltable, _Order);
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

                                if (Selltable.Contains(SellTable.GetSellOrderByOrderId(Convert.ToInt32(stdInputArgumentsArray[0])) ))
                                {
                                    Selltable.Remove(SellTable.GetSellOrderByOrderId(Convert.ToInt32(stdInputArgumentsArray[0])));

                                }
                                else if (Buytable.Contains(BuyTable.GetBuyOrderByOrderId(Convert.ToInt32(stdInputArgumentsArray[0]))))
                                {
                                    Buytable.Remove(BuyTable.GetBuyOrderByOrderId(Convert.ToInt32(stdInputArgumentsArray[0])));
                                }

                                break;
                            }
                           

                       
                     case "MODIFY":
                         {
                               
                                //MODIFY Operation logic
                                if (stdInputArgumentsArray[2] == "SELL" )
                             {
                                    if (!Selltable[Convert.ToInt32(stdInputArgumentsArray[1])].Equals(null))
                                    {
                                        var temp = Selltable[Convert.ToInt32(stdInputArgumentsArray[1])];
                                        if (temp.OrderTrade.Equals(Order_type.IOC) || temp.OrderTrade.Equals(Order_type.INV)) break;

                                        Selltable[Convert.ToInt32(stdInputArgumentsArray[1])].OrderPrice = Convert.ToInt32(stdInputArgumentsArray[3]);
                                        Selltable[Convert.ToInt32(stdInputArgumentsArray[1])].OrderQuantity = Convert.ToInt32(stdInputArgumentsArray[4]);
                                    }

                                }
                                if (stdInputArgumentsArray[2] == "BUY")
                                {
                                      if (!Buytable[Convert.ToInt32(stdInputArgumentsArray[1])].Equals(null))
                                    {
                                        var temp = Buytable[Convert.ToInt32(stdInputArgumentsArray[1])];
                                        if (temp.OrderTrade.Equals(Order_type.IOC) || temp.OrderTrade.Equals(Order_type.INV)) break;

                                        Buytable[Convert.ToInt32(stdInputArgumentsArray[1])].OrderPrice = Convert.ToInt32(stdInputArgumentsArray[3]);
                                        Buytable[Convert.ToInt32(stdInputArgumentsArray[1])].OrderQuantity = Convert.ToInt32(stdInputArgumentsArray[4]);
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


                               SellTrade(kvp1, kvp1.Ticker);

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

                            SellTrade(kvp1, kvp1.Ticker);

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

            }
            catch
            { Console.ReadKey(); }


        }

    }
}


    


    



   








