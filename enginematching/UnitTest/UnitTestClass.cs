
using NUnit.Framework;
using System;
using System.Collections.Generic;

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

            //Exmaple order1 : ABCDEFGH1234" BUY GFD 1000 10 EUR Germany MM/dd/yyyy h:mm tt 02.00:00:00 0.00:00:1000  0order1
            order1.Ticker = "ABCDEFGH1234";
            order1.OperationType = Operation_type.BUY;
            order1.OrderTrade = Order_type.GFD;
            order1.OrderPrice = 1000;
            order1.OrderQuantity = 10;
            order1.Devise = Devise.EUR;
            order1.Country = "Germany";
            order1.DateCreateOrder = DateTime.Now;
            // format TimeSpan dd.hh:mm:ss
            order1.ValidityTimePeriode = new TimeSpan(02, 0, 0, 0);
            order1.ValidityAbsoluteTime = new TimeSpan(0, 0, 0, 1000);

            //Exmaple order2 : ABCDEFGH1234" SELL GFD 900 20 EUR Italy MM/dd/yyyy h:mm tt 01.00:00:00 0.00:00:1000  0order2

          
            order2.Ticker = "ABC0000A1111";
            order2.OperationType = Operation_type.SELL;
            order2.OrderTrade = Order_type.GFD;
            order2.OrderPrice = 900;
            order2.OrderQuantity = 20;
            order2.Devise = Devise.EUR;
            order2.Country = "Italy";
            order2.DateCreateOrder = DateTime.Now;
            // format TimeSpan dd.hh:mm:ss
            order2.ValidityTimePeriode = new TimeSpan(01, 0, 0, 0);
            order2.ValidityAbsoluteTime = new TimeSpan(0, 0, 0, 1000);

            //Exmaple order3 : "ABCD4568DF02" BUY GFD 1010 30 EUR Japon MM/dd/yyyy h:mm tt 01.00:00:00 0.00:00:1000  0order2

            order3.Ticker = "ABCD4568DF02";
            order3.OperationType = Operation_type.BUY;
            order3.OrderTrade = Order_type.GFD;
            order3.OrderPrice = 1010;
            order3.OrderQuantity = 30;
            order3.Devise = Devise.EUR;
            order3.Country = "Japon";
            order3.DateCreateOrder = DateTime.Now;
            // format TimeSpan dd.hh:mm:ss
            order3.ValidityTimePeriode = new TimeSpan(01, 0, 0, 0);
            order3.ValidityAbsoluteTime = new TimeSpan(0, 0, 0, 10000);



        }

        [Test()]
        public void TestOrder()
        {


            Assert.AreNotEqual(order2, order1);



        }
        [Test()]
        public void TestIsValidateAbsoluteTime()
        {

           Assert.IsTrue(order1.IsValidateAbsoluteTime());


        }

        [Test()]
        public void TestGetOrderIdByOrder()
        {

            Order.AddOrder(order1);
            Order.AddOrder(order2);
            Order.AddOrder(order3);
            Assert.AreEqual(1, Order.GetOrderIdByOrder(order2));

        }

        [Test()]
        public void TestAddBuyOrder()
        {

            //Exmaple order1 : ABCDEFGH1234" BUY GFD 1000 10 EUR Germany MM/dd/yyyy h:mm tt 02.00:00:00 0.00:00:1000  0order1
            order1.Ticker = "ABCDEFGH1234";
            order1.OperationType = Operation_type.BUY;
            order1.OrderTrade = Order_type.GFD;
            order1.OrderPrice = 1000;
            order1.OrderQuantity = 10;
            order1.Devise = Devise.EUR;
            order1.Country = "Germany";
            order1.DateCreateOrder = DateTime.Now;
            // format TimeSpan dd.hh:mm:ss
            order1.ValidityTimePeriode = new TimeSpan(02, 0, 0, 0);
            order1.ValidityAbsoluteTime = new TimeSpan(0, 0, 0, 1000);

            //Exmaple order2 : ABCDEFGH1234" SELL GFD 900 20 EUR Italy MM/dd/yyyy h:mm tt 01.00:00:00 0.00:00:1000  0order2


            order2.Ticker = "ABC0000A1111";
            order2.OperationType = Operation_type.SELL;
            order2.OrderTrade = Order_type.GFD;
            order2.OrderPrice = 900;
            order2.OrderQuantity = 60;
            order2.Devise = Devise.EUR;
            order2.Country = "Italy";
            order2.DateCreateOrder = DateTime.Now;
            // format TimeSpan dd.hh:mm:ss
            order2.ValidityTimePeriode = new TimeSpan(01, 0, 0, 0);
            order2.ValidityAbsoluteTime = new TimeSpan(0, 0, 0, 1000);

            //Exmaple order3 : "ABCD4568DF02" BUY GFD 1010 30 EUR Japon MM/dd/yyyy h:mm tt 01.00:00:00 0.00:00:1000  0order2

            order3.Ticker = "ABCD4568DF02";
            order3.OperationType = Operation_type.BUY;
            order3.OrderTrade = Order_type.GFD;
            order3.OrderPrice = 1010;
            order3.OrderQuantity = 30;
            order3.Devise = Devise.EUR;
            order3.Country = "Japon";
            order3.DateCreateOrder = DateTime.Now;
            // format TimeSpan dd.hh:mm:ss
            order3.ValidityTimePeriode = new TimeSpan(01, 0, 0, 0);
            order3.ValidityAbsoluteTime = new TimeSpan(0, 0, 0, 10000);

            //Exmaple order4 : "ABCD4568DF02" BUY GFD 1010 30 EUR Japon MM/dd/yyyy h:mm tt 01.00:00:00 0.00:00:1000  0order2

            order4.Ticker = "ABCD4568DF02";
            order4.OperationType = Operation_type.BUY;
            order4.OrderTrade = Order_type.GFD;
            order4.OrderPrice = 1010;
            order4.OrderQuantity = 30;
            order4.Devise = Devise.EUR;
            order4.Country = "USA";
            order4.DateCreateOrder = DateTime.Now;
            // format TimeSpan dd.hh:mm:ss
            order4.ValidityTimePeriode = new TimeSpan(01, 0, 0, 0);
            order4.ValidityAbsoluteTime = new TimeSpan(0, 0, 0, 10000);


            buytable.AddBuyOrder(order1);
            selltable.AddSellOrder(order2);
            buytable.AddBuyOrder(order3);
            buytable.AddBuyOrder(order4);
            Assert.AreEqual(3, BuyTable.Buytable.Count);

        }

        [Test()]
        // test :Return a List OrderBuy by Ticker from BuyTable
        public void TestGetListBuyOrderByTicker()
        {
           
            Assert.AreEqual(2, BuyTable.GetBuyTableByTicker("ABCD4568DF02").Count);

        }

        [Test()]
        // Test :Remove an Order from BuyTable 
        public void RemoveBuyOrder()
        {
            buytable.RemoveBuyOrder(order3);

            Assert.IsFalse(BuyTable.Buytable.Contains(order3));

        }

        [Test()]
        // Test :Remove an Order from BuyTable 
        public void TestAddBuyOrder2()
        {
            buytable.AddBuyOrder(order3);

            Assert.IsTrue(BuyTable.Buytable.Contains(order3));
           
        }


        [Test()]
        // Test :Return IdOrder of an Order from Buytable collection
        public void TestGetBuyOrderID()
        {
            Assert.AreEqual(0, BuyTable.GetBuyOrderId(order1));
            }


        [Test()]
        //Test :Return an OrderBuy by IdOrder from BuyTable
        public void TestGetBuyOrderByOrderId()
        {
            Assert.AreEqual(order1, BuyTable.GetBuyOrderByOrderId(0));
        }


        [Test()]
        public void TestListBuyTicker()
        {
            Assert.AreEqual(2,BuyTable.ListBuyTicker().Count);

        }


        [Test()]
        public void TestCreateBuyTables()
        {
            Assert.IsTrue(TradeTable.CreateBuyTables().ContainsKey("ABCD4568DF02"));
        }


        }
    }
