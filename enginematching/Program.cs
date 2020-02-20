﻿using System;
namespace enginematching
{


    public class Program
    {
        public static void Main(string[] args)
        {

            Product p1 = new Product();
            Product p2 = new Product();
            Product p3 = new Product();
           
            p1.Ticker = "ABFDHSBR";
            p1.Quantity = Quantity.TONS;
            p1.Designation = "olivier";
            p2.Ticker = "ABCDEFGH";
            p2.Quantity = Quantity.TONS;
            p2.Designation = "Chemical Composition";
            p3.Ticker = "ABCDKLMN";
            p3.Quantity = Quantity.TONS;
            p3.Designation = "corn";

            Product.Products.Add(p1);
            Product.Products.Add(p2);
            Product.Products.Add(p2);
           
            System.Console.WriteLine(p1.Ticker);
            System.Console.WriteLine(p2.Ticker);
            System.Console.WriteLine(p3.Ticker);
        }
    }

}