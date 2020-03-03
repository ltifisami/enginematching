



using System;
using System.Collections.Generic;
using Engine;
using Markets;
using static Engine.CurrencyRates;

namespace EngineMatching
{


    public class Program
    {

        public static void Main(string[] args)
        {

            Market market = new Market
            {
                Ticker = "ABCD"
            };

            MarketManagerFacade marketManagerFacade = new MarketManagerFacade();
            marketManagerFacade.AddMarket(market);

            market.SendOrder();

            Matching matching = new Matching();
            Console.WriteLine();
            Console.WriteLine("OrderBookCollection   :");
            Console.WriteLine();
            matching.WriteOrderBookCollection();
            Console.WriteLine();
            Console.WriteLine("Tradetable   :");

            Console.WriteLine();
            matching.WriteTradeTable();
        }



    }

 }
