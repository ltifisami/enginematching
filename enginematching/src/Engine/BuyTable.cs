using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class BuyTable : IEnumerable<Order>
    {


        private  List<Order> buytable ;
        public  List<Order> Buytable { get => buytable; set => buytable = value; }
      


        // Constructeur BuyTable 
        public BuyTable(Order order)
        {   
            Buytable = new List<Order>();
            if (order.OperationType == Operation_type.BUY )
            {
                Buytable.Add(order);

            }
        }


        //return an OrderBuy by IdOrder from SellTable
        public  Order GetBuyOrderByIdOrder(int idOrder)
        {
           
            return Buytable[idOrder];
        }

        // Remove an Order from BuyTable 
        public void RemoveBuyOrder(Order order)
        {
            if(Buytable.Contains(order))
            {
                Buytable.Remove(order);
            }

        }
        // Add an Order to BuyTable 
        public void AddBuyOrder(Order order)
        {

                Buytable.Add(order);


        }

        //return an Order Buy by Ticker from BuyTable
        public  Order GetBuyOrderByTicker(string Ticker)
        {
            return Buytable.Find(delegate (Order o) { return o.Ticker == Ticker; });
        }

        public IEnumerator<Order> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }

}
