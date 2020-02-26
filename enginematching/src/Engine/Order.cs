
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Engine
{
    //enumerator list for the type of order
    public enum Order_type { IOC, GFD, INV, ICB, DRT, BPR };
    // enumerator list for the type of trade
    public enum Operation_type { BUY, SELL, CANCEL, PRINT, MODIFY };
    //enumerator list for Currency
    public enum Devise { EUR, GBD, YEN, CHF, USD, REM_reminbi };
    // enumarator list for UNIT 
    public enum Quantity { TONS, UNIT };



    // class Order 
    public class Order
    {
        private static List<Order> orders = new List<Order>();
        private string ticker;
        private Operation_type operationType;
        private Order_type orderTrade;
        private int orderQuantity;
        private int orderPrice;
        private Devise devise;
        private string country;
        private DateTime dateCreateOrder;
        private TimeSpan validityTimePeriode;
        private TimeSpan validityAbsoluteTime;

        public string Ticker { get => ticker; set => ticker = value; }
        public Operation_type OperationType { get => operationType; set => operationType = value; }
        public Order_type OrderTrade { get => orderTrade; set => orderTrade = value; }
        public int OrderQuantity { get => orderQuantity; set => orderQuantity = value; }
        public int OrderPrice { get => orderPrice; set => orderPrice = value; }
        public Devise Devise { get => devise; set => devise = value; }
        public DateTime DateCreateOrder { get => dateCreateOrder; set => dateCreateOrder = value; }
        public TimeSpan ValidityTimePeriode { get => validityTimePeriode; set => validityTimePeriode = value; }
        public TimeSpan ValidityAbsoluteTime { get => validityAbsoluteTime; set => validityAbsoluteTime = value; }
        public string Country { get => country; set => country = value; }
        public static List<Order> Orders { get => orders; set => orders = value; }


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
            DateCreateOrder = dateCreateOrder;
            ValidityTimePeriode = validityTimePeriode;
            ValidityAbsoluteTime = validityAbsoluteTime;

        }
        public static void AddOrder(Order order)
        {
            Orders.Add(order);
        }


        // Verify the  validity time Period of an Order 
        public bool IsValidateTimePeriode()
        {
            TimeSpan interval = DateTime.Now - this.DateCreateOrder;

            if (this.ValidityTimePeriode.Days > interval.Days)
                return true;
            else
                return false;

        }

        // Verify the  validity time absolute of an Order 
        public bool IsValidateAbsoluteTime()
        {

            TimeSpan interval = DateTime.Now - DateCreateOrder;

            if (this.ValidityAbsoluteTime.Seconds > interval.Seconds)
                return true;
            else
                return false;

        }

        // check the validity of an Order
        public bool IsValideOrder()
        {
            return true;
        }

        //return an OrderID by from ListOrder
        public static int GetOrderIdByOrder(Order _Order)
        {
            if (Orders.Contains(_Order))
            {
                return orders.IndexOf(_Order);
            }
            return -1;
        }



        public static Order_type GetOrderType(string current_order)
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


        public static Operation_type GetOperationType(string current_order)
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

        public static Devise GetDevise(string current_order)
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
        public static DateTime CovertToDateTime(string dateTime)
        { 
           DateTime dateTimee = new DateTime();
            try
            {
                dateTimee = Convert.ToDateTime(dateTime);
            }
            catch (FormatException)
            {

            }
            return dateTimee;
        }

        public static Order CreateOrder(string[] stdInputArgumentsArray)
        {

            Order _Order = new Order
            {
                //Exmaple :  //Exmaple order1 : ABCDEFGH1234" BUY GFD 1000 10 EUR Germany MM/dd/yyyy h:mm tt 02.00:00:00 0.00:00:1000  0order1
                Ticker = Convert.ToString(stdInputArgumentsArray[0]),
                OperationType = Order.GetOperationType(stdInputArgumentsArray[1]),
                OrderTrade = Order.GetOrderType(stdInputArgumentsArray[2]),
                OrderPrice = Convert.ToInt32(stdInputArgumentsArray[3]),
                OrderQuantity = Convert.ToInt32(stdInputArgumentsArray[4]),
                Devise = Order.GetDevise(stdInputArgumentsArray[5]),
                Country = stdInputArgumentsArray[6],
                DateCreateOrder = Order.CovertToDateTime(stdInputArgumentsArray[7]),
                // format TimeSpan dd.hh:mm:ss
               ValidityTimePeriode = Order.ConvertToTimeSpan(stdInputArgumentsArray[8]),
               ValidityAbsoluteTime = Order.ConvertToTimeSpan(stdInputArgumentsArray[9])
            };


            return _Order;

        }




        // Convert a string_Timespan to TimeSpan
        public static TimeSpan ConvertToTimeSpan(string _timeSpan)
        {

            TimeSpan timeSpan = new TimeSpan();

            try
            {
                timeSpan = TimeSpan.Parse(_timeSpan);
            }
            catch (FormatException)
            {

            }

            return timeSpan;

        }









        /*  // Create an Order from an Array
          static Order objectSetter(Order _order, string[] stdInputArgumentsArray)
          {
              try
              {

                  if (Convert.ToInt32(stdInputArgumentsArray[2]) <= 0 || Convert.ToInt32(stdInputArgumentsArray[3]) <= 0) return _orderTable;
                  _order.order_price = Convert.ToInt32(stdInputArgumentsArray[2]); ;
                  _order.order_quantity = Convert.ToInt32(stdInputArgumentsArray[3]);
                  if (getOrderType(stdInputArgumentsArray[1]).Equals(order_type.GFD))
                  {
                      //GFD Operation
                      _orderTable.order_trade = order_type.GFD;
                  }
                  else if (getOrderType(stdInputArgumentsArray[1]).Equals(order_type.IOC))
                  {
                      //IOC operation
                      _orderTable.order_trade = order_type.IOC;
                  }
                  else _orderTable.order_trade = order_type.INV;

                  return _orderTable;
              }
              catch { return _orderTable; }
          }
          */

    }

}
