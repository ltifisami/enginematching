using System.Collections;
using System.Collections.Generic;

namespace Engine
{
    public class SellTable : IEnumerable<Order>
    {
        private  List<Order> selltable;
        public  List<Order> Selltable { get => selltable; set => selltable = value; }

        // Constructeur SellTable 
        public SellTable(Order order)
        {
            if (order.OperationType == Operation_type.SELL)
            {
                Selltable.Add(order);
               
            }
        }
       

        //return an OrderSell by Ticker from SellTables
        public   Order GetSellOrderByTicker(string Ticker)
        {
            return Selltable.Find(delegate (Order o) { return o.Ticker == Ticker; });
        }

        //return an OrderSell by IdOrder from SellTables
        public  Order GetSellOrderByIdOrder(int idOrder)
        {

            return Selltable[idOrder];
        }

        //Remove an Order Sell from SellTable

        public void RemoveSellOrder(Order order)
        {
            if (Selltable.Contains(order))
            {
                Selltable.Remove(order);
            }

        }

        // Add an Order to SellTable 
        public void AddSellOrder(Order order)
        {

                Selltable.Add(order);


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

}
