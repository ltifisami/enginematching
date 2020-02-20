using NUnit.Framework;
using System;
namespace enginematching
{
    [TestFixture()]
    public class UnitTestClass
    {


        [Test()]
        public void TestCase()
        {


        }
        [Test()]
        public void TestGetProductByTicker(string Ticker)
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
            Assert.AreEqual(p1, Product.GetProductByTicker("ABFDHSBR"));
        }

    }
}
