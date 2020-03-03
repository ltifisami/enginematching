


using System;
using System.Collections.Generic;
using System.Linq;
using static Engine.CurrencyRates;

namespace Engine
{
    public class OrderBook
    {

        public static Dictionary<string, IOrder> OrderBookCollection = new Dictionary<string, IOrder>();
       

        public OrderBook()
        {
        }

        public static void AddOrder(string _OrderId, Order _order)
        {
            if (!OrderBookCollection.ContainsKey(_OrderId))
            {
                _order.OrderId = _OrderId;
                OrderBookCollection.Add(_OrderId, _order);
            }
        }

       



    }
}


















