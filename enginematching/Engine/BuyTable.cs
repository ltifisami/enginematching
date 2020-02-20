namespace enginematching
{
    public class BuyTable
    {


        // return an Order in the OrderBook by Ticker
        public Order GetBuytablebByTicker(string Ticker, OrderBook orderBook)
        {
            Order ot = orderBook.OrderBookCollection[Ticker];
            return ot;

        }
    }

}
