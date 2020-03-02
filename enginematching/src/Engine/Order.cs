﻿
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Engine
{
    //enumerator list for the type of order
    public enum Order_type { IOC, GFD, INV, ICB, DRT, BPR };
    // enumerator list for the type of trade
    public enum Operation_type { BUY , SELL, CANCEL, PRINT, MODIFY };
    //enumerator list for Currency
    public enum Devise { EUR , GBD, CHF, YEN ,USD, REM_reminbi };
    // enumarator list for UNIT 
    public enum Quantity { TONS, UNIT };



    // class Order 
    public class Order : IOrder
    {
        private string orderId;
        private string ticker;
        private Operation_type operationType;
        private Order_type orderTrade;
        private int orderQuantity;
        private int orderPrice;
        private Devise devise;
        private string country;
        private DateTime dateCreateOrder;
        private DateTime dateEndOrder;

        public string Ticker { get => ticker; set => ticker = value; }
        public Operation_type OperationType { get => operationType; set => operationType = value; }
        public Order_type OrderTrade { get => orderTrade; set => orderTrade = value; }
        public int OrderQuantity { get => orderQuantity; set => orderQuantity = value; }
        public int OrderPrice { get => orderPrice; set => orderPrice = value; }
        public Devise Devise { get => devise; set => devise = value; }
        public DateTime DateCreateOrder { get => dateCreateOrder; set => dateCreateOrder = value; }
        public DateTime DateEndOrder { get => dateEndOrder; set => dateEndOrder = value; }
        public string Country { get => country; set => country = value; }
        public  string OrderId { get => orderId; set => orderId = value; }




        // Constructor 
        public Order()
        {

            Ticker = ticker;
            OperationType = operationType;
            OrderTrade = orderTrade;
            OrderQuantity = orderQuantity;
            OrderPrice = orderPrice;
            Devise = devise;
            Country = Country;
            DateCreateOrder = DateTime.Now;
            DateEndOrder = dateEndOrder;

        }

       

        public  Order_type GetOrderType(string current_order)
        {


            if (current_order.Equals("GFD"))
            {
                //GFD operation
                return Order_type.GFD;

            }
            else if (current_order.Equals("IOC"))
            {
                //IOC operation
                return Order_type.IOC;
            }
            else return Order_type.INV;
        }


        public  Operation_type GetOperationType(string current_order)
        {


            if (current_order.Equals("BUY"))
            {
                //GFD operation
                return Operation_type.BUY;

            }
            else if (current_order.Equals("SELL"))
            {
                //IOC operation
                return Operation_type.SELL;
            }
            else if (current_order.Equals("MODIFY"))
            {
                //IOC operation
                return Operation_type.MODIFY;
            }
            else if (current_order.Equals("CANCEL"))
            {
                //IOC operation
                return Operation_type.CANCEL;
            }
            else return Operation_type.PRINT;
        }


        // Covert Devise to string
        public string ConvertDeviseToString(IOrder order)
        {
            if (order.Devise == Devise.EUR)
            {
                return "EUR";

            }
            else if (order.Devise == Devise.USD)
            {
                return "USD";
            }
            else if (order.Devise == Devise.GBD)
            {
                return "GBD";
            }
            else if (order.Devise == Devise.CHF)
            {
                return "CHF";
            }
            else if (order.Devise == Devise.REM_reminbi)
            {
                return "REM_reminbi";
            }
            else return "YEN";
        }



        public  Devise GetDevise(string current_order)
        {


            if (current_order.Equals("EUR"))
            {
                //GFD operation
                return Devise.EUR;

            }
            else if (current_order.Equals("USD"))
            {
                //IOC operation
                return Devise.USD;
            }
            else if (current_order.Equals("GBD"))
            {
                //IOC operation
                return Devise.GBD;
            }
            else if (current_order.Equals("CHF"))
            {
                //IOC operation
                return Devise.CHF;
            }
            else if (current_order.Equals("REM_reminbi"))
            {
                //IOC operation
                return Devise.REM_reminbi;
            }
            else return Devise.YEN;
        }


        public Order CreateOrder(string[] stdInputArgumentsArray)
        {
            string dateEnd = String.Concat(stdInputArgumentsArray[7] ," " ,stdInputArgumentsArray[8]);
                       Order _Order = new Order
            {
                //Exmaple order1 :  BUY GFD 1000 10 EUR ABCDEFGH1234 Germany MM-DD-yyyy h:mm:tt order1

                OperationType = this.GetOperationType(stdInputArgumentsArray[0]),
                OrderTrade = this.GetOrderType(stdInputArgumentsArray[1]),
                OrderPrice = Convert.ToInt32(stdInputArgumentsArray[2]),
                OrderQuantity = Convert.ToInt32(stdInputArgumentsArray[3]),
                Devise = this.GetDevise(stdInputArgumentsArray[4]),
                Ticker = Convert.ToString(stdInputArgumentsArray[5]),
                Country = stdInputArgumentsArray[6],
                DateEndOrder= Convert.ToDateTime(dateEnd),
                OrderId = Convert.ToString(stdInputArgumentsArray[9])
            };
            if (DateTime.Compare(_Order.DateEndOrder, _Order.DateCreateOrder) < 0) return null;

            return _Order;

        }

        // Return a List of Orders between startTime and endTime
         public List<IOrder> GetOrders(DateTime start, DateTime end)
        {
            List<IOrder> _orders = new List<IOrder>();

            foreach(var order in OrderBook.OrderBookCollection.Values)
            {
                if (DateTime.Compare(start, order.DateCreateOrder)  <= 0  && DateTime.Compare(end , order.DateEndOrder) <= 0) _orders.Add(order);
            }
            return _orders;
        }
    }

}
