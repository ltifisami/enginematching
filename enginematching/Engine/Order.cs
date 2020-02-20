
using System;


namespace enginematching
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


    }

}
