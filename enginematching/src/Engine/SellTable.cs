using System.Collections;
using System.Collections.Generic;

namespace Engine
{
    public class SellTable
    {


        private static List<Order> selltable = new List<Order>();
        public static List<Order> Selltable { get => selltable; set => selltable = value; }




        // Constructeur BuyTable 
        public SellTable(Order _order)
        {

            if (_order.OperationType == Operation_type.SELL)
            {
                Selltable.Add(_order);

            }
        }

        public SellTable()
        {

            selltable = Selltable;
        }

        // return IdOrder of an Order from Buytable collection
        public static int GetSellOrderId(Order _order)
        {
            if (Selltable.Contains(_order))
            {
                return Selltable.IndexOf(_order);
            }
            else
            {
                return -1;
            }
        }


        //return an OrderBuy by IdOrder from BuyTable
        public static Order GetSellOrderByOrderId(int idOrder)
        {

            return Selltable[idOrder];

        }

        // Remove an Order from BuyTable 
        public void RemoveBuyOrder(Order order)
        {
            if (Selltable.Contains(order))
            {
                Selltable.Remove(order);
            }

        }
        // Add an Order to BuyTable 
        public void AddSellOrder(Order _order)
        {


            if (_order.OperationType == Operation_type.BUY && !Selltable.Contains(_order))
            {
                Selltable.Add(_order);

            }
        }

        //Return SellTable by Ticker 
        public static List<Order> GetSellTableByTicker(string _Ticker)
        {
            List<Order> Orderlist = new List<Order>();
            foreach (var sellOrder in Selltable)
            {
                if (sellOrder.Ticker == _Ticker)
                {
                    Orderlist.Add(sellOrder);
                }

            }
            return Orderlist;

        }

        // Return List of SellTicker from Selltable

        public static List<string> ListSellTicker()
        {
            List<string> listTicker = new List<string>();
            foreach (var order in Selltable)
            {
                if (!listTicker.Contains(order.Ticker))
                    listTicker.Add(order.Ticker);
            }
            return listTicker;
        }

    }
}


