



using System;
using System.Collections.Generic;
using Engine;
using static Engine.CurrencyRates;

namespace EngineMatching
{


    public class Program
    {

        public static void Main(string[] args)
        {


           
                OrderBook orderBook = new OrderBook();


                orderBook.CreateOrderBook();

                Console.WriteLine("OrderBookCollection   :");
                Console.WriteLine();
                orderBook.WriteOrderBookCollection();
                Console.WriteLine("Tradetable   :");
                Console.WriteLine();
                orderBook.WriteTradeTable();
               
               
            }



     }

 }
