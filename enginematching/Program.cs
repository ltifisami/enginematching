
using System;
using System.Collections.Generic;


namespace enginematching
{


    //enumerator list for the type of order
    public enum Order_type { IOC, GFD, INV, ICB, DRT, BPR };
      // enumerator list for the type of trade
    public enum Operation_type { BUY, SELL, CANCEL, PRINT, MODIFY };
      //enumerator list for Currency
    public enum Devise { EUR,GBD , YEN, CHF, USD,REM_reminbi };
    // enumarator list for UNIT 
    public enum Quantity { TONS, UNIT };

    public class Produit
    {
        private string TICKER { get; set; }
        private string Designation { get; set; }
        private Quantity quantity { get; set; }

        public Produit(string tICKER, string designation, Quantity _quantity)
        {
            TICKER = tICKER;
            Designation = designation;
            quantity = _quantity;
        }


    }


    // class Price_delta_range
    public class Price_delta_range
    {

        public int Range1 { set; get; }
        public int Range2 { set; get; }
        public float Price_delta { set; get; }
        public Devise Devise { set; get; }


        public Price_delta_range(int _range1, int _range2, Devise _devise, int v, float _price_delta)
        {
            Range1 = _range1;
            Range2 = _range2;
            Devise = _devise;
            Price_delta = _price_delta;
        }




    }

    


   
    public class Buytable
    {

         
       
        public Order_table Get_Buytable_by_TICKER(string _TICKER, Book_ordre Book_Ordre)
        {
            Order_table ot = null;
            foreach (var kpv in Book_Ordre.book_ordre)
            {
                if (kpv.Value.TICKER == _TICKER && kpv.Value.Operation_Type == Operation_type.BUY  )
                {
                    ot = kpv.Value;
                }
            }
            return ot;

        }
    }

    public class Selltable 
    {
        public Order_table Get_Selltable_by_TICKER(string _TICKER, Book_ordre Book_Ordre)
        {
            Order_table ot = null;
            foreach (var kpv in Book_Ordre.book_ordre)
            {
                if (kpv.Value.TICKER == _TICKER && kpv.Value.Operation_Type == Operation_type.SELL)
                {
                    ot = kpv.Value;
                }
            }
            return ot;

        }
    }
    public class Tradetable
    {


        public Order_type Order_trade_buy { set; get; }
        public int Order_quantity_buy { set; get; }
        public int Order_price_buy { set; get; }
        public Devise Devise_buy { set; get; }
        public string Country_buy { set; get; }
        public DateTime Date_Create_Order_buy { get; set; }
        public TimeSpan ValidityTimePeriode_buy { get; set; }
        public TimeSpan ValidityAbsoluteTime_buy { get; set; }


        public Order_type Order_trade_sell { set; get; }
        public int Order_quantity_sell { set; get; }
        public int Order_price_sell { set; get; }
        public Devise Devise_sell { set; get; }
        public string Country_sell { set; get; }
        public DateTime Date_Create_Order_sell { get; set; }
        public TimeSpan ValidityTimePeriode_sell { get; set; }
        public TimeSpan ValidityAbsoluteTime_sell { get; set; }

        // constructeur Tradetable
        public Tradetable(Order_type order_trade_buy, int order_quantity_buy, int order_price_buy, Devise devise_buy, string country_buy, DateTime date_Create_Order_buy, TimeSpan validityTimePeriode_buy, TimeSpan validityAbsoluteTime_buy, Order_type order_trade_sell, int order_quantity_sell, int order_price_sell, Devise devise_sell, string country_sell, DateTime date_Create_Order_sell, TimeSpan validityTimePeriode_sell, TimeSpan validityAbsoluteTime_sell)
        {
            Order_trade_buy = order_trade_buy;
            Order_quantity_buy = order_quantity_buy;
            Order_price_buy = order_price_buy;
            Devise_buy = devise_buy;
            Country_buy = country_buy;
            Date_Create_Order_buy = date_Create_Order_buy;
            ValidityTimePeriode_buy = validityTimePeriode_buy;
            ValidityAbsoluteTime_buy = validityAbsoluteTime_buy;
            Order_trade_sell = order_trade_sell;
            Order_quantity_sell = order_quantity_sell;
            Order_price_sell = order_price_sell;
            Devise_sell = devise_sell;
            Country_sell = country_sell;
            Date_Create_Order_sell = date_Create_Order_sell;
            ValidityTimePeriode_sell = validityTimePeriode_sell;
            ValidityAbsoluteTime_sell = validityAbsoluteTime_sell;
        }
    }
    public class SettlementTable
    {
        private string tICKER;
        public string Paye_liv { set; get; }
        public string Adresse_liv { set; get; }

        public SettlementTable(string tICKER, string paye_liv, string adresse_liv)
        {
            this.tICKER = tICKER;
            Paye_liv = paye_liv;
            Adresse_liv = adresse_liv;
        }

        public string GetTICKER()
        {
            return tICKER;
        }

        public void SetTICKER(string value)
        {
            tICKER = value;
        }




    }
    public class Order_table
    {
        public string TICKER { get; set; }
        public Operation_type Operation_Type { set; get; }
        public Order_type Order_trade { set; get; }
        public int Order_quantity { set; get; }
        public int Order_price { set; get; }
        public Devise Devise { set; get; }
        public string Country { set; get; }
        public DateTime Date_Create_Order { get; set; }
        public TimeSpan ValidityTimePeriode { get; set; }
        public TimeSpan ValidityAbsoluteTime { get; set; }
       
       


        public Order_table(Operation_type operation_type1, int order_quantity, int order_price, Order_type order_trade, Devise _devise, string country, TimeSpan validityTimePeriode, TimeSpan validityAbsoluteTime, string tICKER)
        {
            Date_Create_Order = DateTime.Now;
            Operation_Type = operation_type1;
            Order_quantity = order_quantity;
            Order_price = order_price;
            Order_trade = order_trade;
            Devise = _devise;
            Country = country;
            ValidityTimePeriode = validityTimePeriode;
            ValidityAbsoluteTime = validityAbsoluteTime;
            TICKER = tICKER;
        }
       
        public Order_table()
        {
        }

        public bool Is_validate_time_periode()
        {
            bool val = true;
            return val;
        }
        public bool Is_validate_absolute_time()
        {
          
            TimeSpan interval = DateTime.Now - this.Date_Create_Order;

            if (this.ValidityAbsoluteTime > interval)
                return true;
            else
                return false;

        }
        public void Description_order()
        {
            Console.WriteLine("le TICKS est "+this.TICKER+
            "\n la  Date_Create_Order est " + this.Date_Create_Order +
               "\nle Type d'operation est " + this.Operation_Type +
            "\n le quantity est " + this.Order_quantity +
               "\n le Order_type est " + this.Order_trade +
            "\n le  Devise est " + this.Devise +
               "\n ValidityTimePeriode est : " + this.ValidityTimePeriode +
            "\n ValidityAbsoluteTime est " + this.ValidityAbsoluteTime
              );

        }
    }

    public class Book_ordre
    {


        public Dictionary<string, Order_table> book_ordre;

        public Book_ordre(Dictionary<string, Order_table> book_ordre)
        {
            this.book_ordre = book_ordre;
        }


        public void Add_Order(string TIKER, Order_table ordertable)
        {
            book_ordre.Add(TIKER, ordertable);
        }


        public Order_table Get_Order_by_TICKER(string _TIKER, Dictionary<string, Order_table> book_ordre)
        {
            Order_table ot = null;

            foreach (var kpv in book_ordre)
            {
                if (kpv.Value.TICKER == _TIKER)
                    ot = kpv.Value;
            }
            return ot;
        }

    }



    // Classe Market 
    public class Market
    {
        private string TICKER { set; get; }


        // fixingPeriod est exprimé en secondes
        private int FixingPeriod { set; get; }

        public DateTime MarketInitDate { get; }
        public int Max_Quantity { set; get; }
        public int Min_Quantity { set; get; }
        public Quantity Description { set; get; }
        public float Price_delta { set; get; }
        public Price_delta_range P_d_r { set; get; }

        public Dictionary<string, Buytable> buyTable { set; get; }
        public Dictionary<string, Selltable> sellTable { set; get; }


        private Dictionary<string, SettlementTable> SettlementTable { set; get; }
        private Dictionary<string, Tradetable> Tradetable { set; get; }



        // constructeur avec le paramatere FixingPeriod "ADMIN"
        public Market(string tICKER, int fixingPeriod, DateTime marketInitDate, 
            int max_Quantity, int min_Quantity, Quantity description, float price_delta,
             Price_delta_range p_d_r, Dictionary<string, Buytable> _buyTable,
             Dictionary<string, Selltable> _sellTable, Dictionary<string, SettlementTable> _settlementTable,
              Dictionary<string, Tradetable> _tradeTable)
        {
            TICKER = tICKER;
            FixingPeriod = fixingPeriod;
            MarketInitDate = marketInitDate;
            Max_Quantity = max_Quantity;
            Min_Quantity = min_Quantity;
            Description = description;
            Price_delta = price_delta;
            P_d_r = p_d_r;
            buyTable = _buyTable;
            sellTable=_sellTable;
            SettlementTable = _settlementTable;
            Tradetable = _tradeTable;
        }

        // Constructeur sans le parametre FixingPeriod
        public Market(string tICKER, DateTime marketInitDate, int max_Quantity, int min_Quantity, Quantity description, float price_delta, Price_delta_range p_d_r, Dictionary<string, Buytable> _buyTable, Dictionary<string, Selltable> _sellTable, Dictionary<string ,SettlementTable> _settlementTable, Dictionary<string, Tradetable> _tradeTable)
        {
            TICKER = tICKER;
            MarketInitDate = marketInitDate;
            Max_Quantity = max_Quantity;
            Min_Quantity = min_Quantity;
            Description = description;
            Price_delta = price_delta;
            P_d_r = p_d_r;
            buyTable = _buyTable;
            sellTable = _sellTable;
            SettlementTable = _settlementTable;
            Tradetable = _tradeTable;
        }
    }


    public class user
    {

    }


    public class Program
    {

        public static void Main(string[] args)
        {

            Price_delta_range pdr1 = new Price_delta_range(10, 1000,Devise.EUR, 0,5);
            Console.WriteLine(pdr1.Range1);
            Console.WriteLine(pdr1.Range2);
            Console.WriteLine(pdr1.Devise);
            Console.WriteLine(pdr1.Price_delta);
            pdr1.Range1 = 20;
            Console.WriteLine(pdr1.Range1);
            Console.WriteLine(Order_type.BPR);
            Console.WriteLine("//////////////////////////////////////////////////////");
            Order_table ot = new Order_table(Operation_type.BUY, 1000, 10, Order_type.GFD, Devise.USD, "USA", new TimeSpan(1,0,0), new TimeSpan(2, 0, 0), "SADERF");

            ot.Description_order();
            if(ot.Is_validate_absolute_time() == true)
            {
                Console.WriteLine("Is_validate_absolute_time");
            }
            List<string> st= Countryliste.Country_Liste();


            foreach( string k in st) 
            {
                Console.WriteLine(k);
                }



        }


    }

}
