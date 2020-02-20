using System.Collections.Generic;


namespace enginematching
{
    public class OrderBook
    {

        // Generic Collection contains all the Order
        public IDictionary<string, Order> OrderBookCollection;

        //Constructor 
        public OrderBook(IDictionary<string, Order> OrderBookCollection)
        {
            this.OrderBookCollection = OrderBookCollection;
        }

        // methode to add a new Order in the order book collection
        public void AddOrder(string Ticker, Order order)
        {
            OrderBookCollection.Add(Ticker, order);
        }

        //methode return an order in the order book collection by Tiker
        public Order GetOrderbyTicker(string Ticker, IDictionary<string, Order> OrderBookCollection)
        {
            Order ot = OrderBookCollection[Ticker];
            return ot;
        }

    }

}
