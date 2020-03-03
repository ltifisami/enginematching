
using NUnit.Framework;
using System;
using System.Collections.Generic;
using static Engine.CurrencyRates;

namespace Engine
{
    [TestFixture()]
    public class UnitTestOrder
    {
        Order order1 = new Order();
        Order order2 = new Order();
        Order order3 = new Order();
        Order order4 = new Order();
        Order order5 = new Order();
        BuyTable buytable = new BuyTable();
        SellTable selltable = new SellTable();

        [Test()]
        public  void TestCase()
        {

            //Exmaple order1 : ABCDEFGH1234 BUY GFD 1000 10 EUR Germany MM/dd/yyyy h:mm tt 02.00:00:00 0.00:00:1000  0order1

            order1.Ticker = "ABCDEFGH1234";
            order1.OperationType = Operation_type.BUY;
            order1.OrderTrade = Order_type.GFD;
            order1.OrderPrice = 1000;
            order1.OrderQuantity = 10;
            order1.Devise = Devise.EUR;
            order1.Country = "Germany";
            order1.DateCreateOrder = DateTime.Now;

             //Exmaple order2 : ABCDEFGH1234" SELL GFD 900 20 EUR Italy MM/dd/yyyy h:mm tt 01.00:00:00 0.00:00:1000  0order2


            order2.Ticker = "ABC0000A1111";
            order2.OperationType = Operation_type.SELL;
            order2.OrderTrade = Order_type.GFD;
            order2.OrderPrice = 900;
            order2.OrderQuantity = 20;
            order2.Devise = Devise.EUR;
            order2.Country = "Italy";
            order2.DateCreateOrder = DateTime.Now;
           
            //Exmaple order3 : "ABCD4568DF02" BUY GFD 1010 30 EUR Japon MM/dd/yyyy h:mm tt 01.00:00:00 0.00:00:1000  0order2

            order3.Ticker = "ABCD4568DF02";
            order3.OperationType = Operation_type.BUY;
            order3.OrderTrade = Order_type.GFD;
            order3.OrderPrice = 1010;
            order3.OrderQuantity = 30;
            order3.Devise = Devise.EUR;
            order3.Country = "Japon";
            order3.DateCreateOrder = DateTime.Now;
           


        }

        [Test()]
        public void TestOrder()
        {


            Assert.AreNotEqual(order2, order1);



        }
       


        [Test()]
        public void TestAddBuyOrder()
        {

            //Exmaple order1 : ABCDEFGH1234" BUY GFD 1000 10 EUR Germany MM/dd/yyyy h:mm tt 02.00:00:00 0.00:00:1000  0order1
            order1.Ticker = "ABCDEFGH1234";
            order1.OperationType = Operation_type.BUY;
            order1.OrderTrade = Order_type.GFD;
            order1.OrderPrice = 10;
            order1.OrderQuantity = 10;
            order1.Devise = Devise.EUR;
            order1.Country = "Germany";
            order1.DateCreateOrder = DateTime.Now;

            //Exmaple order2 : ABCDEFGH1234" SELL GFD 900 20 EUR Italy MM/dd/yyyy h:mm tt 01.00:00:00 0.00:00:1000  0order2


            order2.Ticker = "ABC0000A1111";
            order2.OperationType = Operation_type.SELL;
            order2.OrderTrade = Order_type.GFD;
            order2.OrderPrice = 900;
            order2.OrderQuantity = 60;
            order2.Devise = Devise.EUR;
            order2.Country = "Italy";
            order2.DateCreateOrder = DateTime.Now;

            //Exmaple order3 : "ABCD4568DF02" BUY GFD 1010 30 EUR Japon MM/dd/yyyy h:mm tt 01.00:00:00 0.00:00:1000  0order2

            order3.Ticker = "ABCD4568DF02";
            order3.OperationType = Operation_type.BUY;
            order3.OrderTrade = Order_type.GFD;
            order3.OrderPrice = 1010;
            order3.OrderQuantity = 30;
            order3.Devise = Devise.EUR;
            order3.Country = "Japon";
            order3.DateCreateOrder = DateTime.Now;
           
            //Exmaple order4 : "ABCD4568DF02" BUY GFD 1010 30 EUR Japon MM/dd/yyyy h:mm tt 01.00:00:00 0.00:00:1000  0order2

            order4.Ticker = "ABCD4568DF02";
            order4.OperationType = Operation_type.BUY;
            order4.OrderTrade = Order_type.GFD;
            order4.OrderPrice = 1010;
            order4.OrderQuantity = 30;
            order4.Devise = Devise.EUR;
            order4.Country = "USA";
            order4.DateCreateOrder = DateTime.Now;
           
          
        }

       
   

        [Test()]
        public void TestOrderCovertToDollar()
        {

            //Exmaple order1 : ABCDEFGH1234" BUY GFD 1000 10 EUR Germany MM/dd/yyyy h:mm tt 02.00:00:00 0.00:00:1000  0order1
            order5.Ticker = "ABCDEFGH1234";
            order5.OperationType = Operation_type.BUY;
            order5.OrderTrade = Order_type.GFD;
            order5.OrderPrice = 1000;
            order5.OrderQuantity = 10;
            order5.Devise = Devise.EUR;
            order5.Country = "Germany";
            Matching matching = new Matching();


            Assert.AreEqual(906.799000, matching.CovertToDollar(order5));



        }

    }
    }
