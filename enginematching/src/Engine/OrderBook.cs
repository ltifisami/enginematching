using System.Collections.Generic;


namespace Engine
{
    public class OrderBook
    {

        // Generic Collection contains all the Order
        public IDictionary<string, Order> OrderBookCollection;

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



        public void CreateOrderBook()
        {
            /*
            string[] stdInputArgumentsArray = new string[] { };

            //Reading the standard input arguments and spilt them based on spaces
            //Exmaple : BUY GFD 1000 10 order1
            //All the spilt argemtns are saved to an array named stdInputArgumentsArray

            //Console.Read();
            List<string> stdInput = new List<string>();

            string currentLine = " ";

            foreach (var line in stdInput)
            {
                stdInputArgumentsArray = line.Split(null);


                //Checks if the Trade statement is right
                if (isValidTrade(stdInputArgumentsArray[0], stdInputArgumentsArray))
                {
                    switch (stdInputArgumentsArray[0])
                    {
                        case BUY_LABEL:
                            {
                                //BUY Operation logic
                                try
                                {
                                    order_table _orderTable = new order_table();
                                    _orderTable = objectSetter(_orderTable, stdInputArgumentsArray);
                                    buyTable.Add((stdInputArgumentsArray[4]), _orderTable);
                                }
                                catch
                                {
                                    Console.WriteLine("Error?");
                                }
                                break;
                            }
                        case SELL_LABEL:
                            {
                                //SELL Operation logic
                                try
                                {
                                    order_table _orderTable = new order_table();
                                    _orderTable = objectSetter(_orderTable, stdInputArgumentsArray);
                                    sellTable.Add((stdInputArgumentsArray[4]), _orderTable);
                                }
                                catch
                                {
                                    Console.WriteLine("Repeated?");
                                }
                                break;
                            }
                        case CANCEL_LABEL:
                            {
                                //CANCEL Operation logic
                                //Removing Sell and BUY tabel entry
                                if (sellTable.ContainsKey(stdInputArgumentsArray[1]))
                                {
                                    sellTable.Remove(stdInputArgumentsArray[1]);

                                }
                                else if (buyTable.ContainsKey(stdInputArgumentsArray[1]))
                                {
                                    buyTable.Remove(stdInputArgumentsArray[1]);
                                }

                                break;
                            }
                        case MODIFY_LABEL:
                            {

                                //MODIFY Operation logic
                                if (stdInputArgumentsArray[2].Equals(SELL_LABEL))
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

                        default:
                            break;
                    }
                }

            }


            try
            {
                //Let's Trade
                if (stdInputArgumentsArray[0].Equals(PRINT_LABEL) && isTrade())
                {
                    //Console.Write("Here");
                    //tempSellTable = sellTable;
                    // try
                    {
                        var totalNumberOfSellOrders = sellTable.Count;
                        //llTable.
                        int indexSellTable = 0;
                        // var tempSellTable = sellTable;
                        while (indexSellTable < totalNumberOfSellOrders)
                        {
                            foreach (var kvp1 in sellTable.ToArray())
                            {

                                // var currentSellOrderTrade = kvp1.Value.order_trade;
                                // Console.WriteLine("Let's Trade");

                                sellTrade(kvp1.Key.ToString());




                                //var flattenList = buyTable.SelectMany(x => x.Value.order_price);
                                //getAllBuysGreaterThanMine();
                            }
                            indexSellTable++;
                        }
                        foreach (var kvp1 in sellTable.ToArray())
                        {
                            if (kvp1.Value.order_trade.Equals(order_type.IOC))
                            {
                                sellTable.Remove(kvp1.Key);
                            }
                        }

                        foreach (var kvp1 in buyTable.ToArray())
                        {
                            if (kvp1.Value.order_trade.Equals(order_type.IOC))
                            {
                                buyTable.Remove(kvp1.Key);
                            }
                        }
                    }
                    // catch { }
                    printOperation();
                }

                //check for SELL AND BUY Tables for suitable trades.
                else if (!isTrade() && stdInputArgumentsArray[0].Equals(PRINT_LABEL))
                {
                    printOperation();
                }
                else if (isTrade())
                {
                    var totalNumberOfSellOrders = sellTable.Count;
                    //llTable.
                    int indexSellTable = 0;
                    // var tempSellTable = sellTable;
                    while (indexSellTable < totalNumberOfSellOrders)
                    {
                        foreach (var kvp1 in sellTable.ToArray())
                        {

                            // var currentSellOrderTrade = kvp1.Value.order_trade;
                            // Console.WriteLine("Let's Trade");

                            sellTrade(kvp1.Key.ToString());
                            //var flattenList = buyTable.SelectMany(x => x.Value.order_price);
                            //getAllBuysGreaterThanMine();
                        }
                        indexSellTable++;

                    }

                    foreach (var kvp1 in sellTable.ToArray())
                    {
                        if (kvp1.Value.order_trade.Equals(order_type.IOC))
                        {
                            sellTable.Remove(kvp1.Key);
                        }
                    }

                    foreach (var kvp1 in buyTable.ToArray())
                    {
                        if (kvp1.Value.order_trade.Equals(order_type.IOC))
                        {
                            buyTable.Remove(kvp1.Key);
                        }
                    }


                }
                Console.ReadKey();
            }
            catch
            { Console.ReadKey(); }

            Console.ReadKey();
        }

        //
        static void generatePrintTable()
        {
            foreach (var kvp1 in sellTable)
            {
                try
                {
                    printSellOrderTable.Add(kvp1.Value.order_price, kvp1.Value.order_quantity);
                }
                catch
                {
                    printSellOrderTable[kvp1.Value.order_price] += kvp1.Value.order_quantity;
                }
            }

            foreach (var kvp1 in buyTable)
            {
                try
                {
                    printBuyOrderTable.Add(kvp1.Value.order_price, kvp1.Value.order_quantity);
                }
                catch
                {
                    printBuyOrderTable[kvp1.Value.order_price] += kvp1.Value.order_quantity;
                }
            }
            */

        }










    }

}



