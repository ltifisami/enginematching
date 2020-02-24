
using System;
using System.Collections.Generic;

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
        private static List<Order> Orders = new List<Order>();
        private string ticker;
        private Operation_type operationType;
        private Order_type orderTrade;
        private int orderQuantity;
        private int orderPrice;
        private Devise devise;
        private CountryList country;
        private DateTime dateCreateOrder;
        private TimeSpan validityTimePeriode;
        private TimeSpan validityAbsoluteTime;

        public string Ticker { get => ticker; set => ticker = value; }
        public Operation_type OperationType { get => operationType; set => operationType = value; }
        public Order_type OrderTrade { get => orderTrade; set => orderTrade = value; }
        public int OrderQuantity { get => orderQuantity; set => orderQuantity = value; }
        public int OrderPrice { get => orderPrice; set => orderPrice = value; }
        public Devise Devise { get => devise; set => devise = value; }
        public CountryList Country { get => country; set => country = value; }
        public DateTime DateCreateOrder { get => dateCreateOrder; set => dateCreateOrder = value; }
        public TimeSpan ValidityTimePeriode { get => validityTimePeriode; set => validityTimePeriode = value; }
        public TimeSpan ValidityAbsoluteTime { get => validityAbsoluteTime; set => validityAbsoluteTime = value; }

        // Constructor 
        public Order()
        {
            Ticker = ticker;
            OperationType = operationType;
            OrderTrade = orderTrade;
            OrderQuantity = orderQuantity;
            OrderPrice = orderPrice;
            Devise = devise;
            Country = country;
            DateCreateOrder = dateCreateOrder;
            ValidityTimePeriode = validityTimePeriode;
            ValidityAbsoluteTime = validityAbsoluteTime;
        }

      

        // Verify the  validity time Period of an Order 
        public bool IsValidateTimePeriode()
        {
            TimeSpan interval = DateTime.Now - this.DateCreateOrder;

            if (this.ValidityTimePeriode > interval)
                return true;
            else
                return false;

        }

        // Verify the  validity time absolute of an Order 
        public bool IsValidateAbsoluteTime()
        {

            TimeSpan interval = DateTime.Now - this.DateCreateOrder;

            if (this.ValidityAbsoluteTime > interval)
                return true;
            else
                return false;

        }

        // check the validity of an Order
        public bool IsValideOrder()
        {
            return true;
        }


        // return an Order by Ticker
        public static Order GetOrderByTicker(string Ticker)
        {
            return Orders.Find(delegate (Order o) { return o.ticker == Ticker; });
        }



        /* add order 
        static order_table objectSetter(order_table _orderTable, string[] stdInputArgumentsArray)
        {
            try
            {

                if (Convert.ToInt32(stdInputArgumentsArray[2]) <= 0 || Convert.ToInt32(stdInputArgumentsArray[3]) <= 0) return _orderTable;
                _orderTable.order_price = Convert.ToInt32(stdInputArgumentsArray[2]); ;
                _orderTable.order_quantity = Convert.ToInt32(stdInputArgumentsArray[3]);
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
