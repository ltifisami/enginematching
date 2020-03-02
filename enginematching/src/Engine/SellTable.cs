using System.Collections;
using System.Collections.Generic;

namespace Engine
{
    public class SellTable
    {


        private static List<IOrder> selltable = new List<IOrder>();
        public static List<IOrder> Selltable { get => selltable; set => selltable = value; }




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
        public static IOrder GetSellOrderByOrderId(int idOrder)
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

      

    }
}


