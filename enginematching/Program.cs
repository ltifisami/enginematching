



using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Engine;
using Markets;
using static Engine.CurrencyRates;

namespace EngineMatching
{


    public class Program
    {
        static  System.Timers.Timer aTimer;

        public static void Main(string[] args)
        {

            /*
            // Market with MTCHING_TYPE = MANUAL
            Market Manualmarket = new Market
            {
                Ticker = "ABCD",
                DirectPartialOrderMatchingEnable = true
            }

             Manualmarket.SendOrder();
             Matching matching = new Matching();
             Console.WriteLine();
             Console.WriteLine("OrderBookCollection   :");
             Console.WriteLine();
             matching.WriteOrderBookCollection();
             Console.WriteLine();
             Console.WriteLine("Tradetable   :");
             Console.WriteLine();
             matching.WriteTradeTable();
            */


            /* 
            // Market with MTCHING_TYPE = MarketPlace_AVEREGE
             Market MarketPlace_AVEREGE_market = new Market
             {
                 Ticker = "abcd",
                 MatchingType = Matching_Type.MarketPlace_AVEREGE

             };
        
             MarketPlace_AVEREGE_market.SendOrder();

             Matching matching = new Matching();
             Console.WriteLine();
             Console.WriteLine("OrderBookCollection   :");
             Console.WriteLine();
             matching.WriteOrderBookCollection();
             Console.WriteLine();
             Console.WriteLine("Tradetable   :");

             Console.WriteLine();
             matching.WriteTradeTable();
             */
            /*

           // Create a Market with Matching Type MarketPlace_BESTBUY
           Market MarketPlace_BESTBUY_market = new Market
           {
               Ticker = "abcd",
               MatchingType = Matching_Type.MarketPlace_BESTBUY

           };

           MarketPlace_BESTBUY_market.SendOrder();

           Matching matching = new Matching();
           Console.WriteLine();
           Console.WriteLine("OrderBookCollection   :");
           Console.WriteLine();
           matching.WriteOrderBookCollection();
           Console.WriteLine();
           Console.WriteLine("Tradetable   :");

           Console.WriteLine();
           matching.WriteTradeTable();

   */

            /*
            Console.WriteLine("\n\n Market :");
           
            // Create a Market with Matching Type MarketPlace_BESTSELL
            Market MarketPlace_BESTSELL_market = new Market
            {
                Ticker = "abcd",
                MatchingType = Matching_Type.MarketPlace_BESTSELL

            };
            Console.WriteLine(" Matching_Type :    MarketPlace_BESTSELL \n\n");


            MarketPlace_BESTSELL_market.SendOrder();

            Matching matching = new Matching();
            Console.WriteLine();
            Console.WriteLine("OrderBookCollection   :");
            Console.WriteLine();
            matching.WriteOrderBookCollection();
            Console.WriteLine();
            Console.WriteLine("Tradetable   :");
            Console.WriteLine();
            matching.WriteTradeTable();



    */




             

        }


    }

 }
