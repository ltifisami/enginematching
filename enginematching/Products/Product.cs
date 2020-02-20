using System.Collections.Generic;


namespace enginematching
{
    //Class Product
    public class Product
    {
        private string ticker;
        private Quantity quantity;
        private string designation;
        private static List<Product> products = new List<Product>();
        public string Ticker { get => ticker; set => ticker = value; }
        public Quantity Quantity { get => quantity; set => quantity = value; }
        public string Designation { get => designation; set => designation = value; }
        public static List<Product> Products { get => products; set => products = value; }



        // Constructor  
        public Product()
        {
            Ticker = ticker;
            Quantity = quantity;
            Designation = designation;
        }

        // return Product by Ticker
        public static Product GetProductByTicker(string Ticker)
        {
            return Products.Find(delegate (Product p) { return p.ticker == Ticker; });
        }

    }

}
