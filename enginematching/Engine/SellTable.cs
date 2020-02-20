namespace enginematching
{
    public class SellTable
    {
        //return an order in the OrderBook by Ticker
        public Order GetSellTableByTicker(string Ticker, OrderBook orderBook)
        {
            Order ot = orderBook.OrderBookCollection[Ticker];
            return ot;

        }
    }

}
