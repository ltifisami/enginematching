using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class BuyTable
    {

       
        private static List<IOrder> buytable = new List<IOrder>();
        public static List<IOrder> Buytable { get => buytable; set => buytable = value; }




        // Constructeur BuyTable 
        public BuyTable(Order _order)
        {

            if (_order.OperationType == Operation_type.BUY)
            {
                Buytable.Add(_order);

            }
        }

        public BuyTable()
        {
           
            buytable = Buytable;
        }

        // return OrderId of an Order from Buytable 
        public static int GetBuyOrderId(Order _order)
        {
            if (Buytable.Contains(_order))
            {
                return Buytable.IndexOf(_order);
            }
            else
            {
                return -1;
            }
        }


        //return an OrderBuy by IdOrder 
        public static IOrder GetBuyOrderByOrderId(int idOrder)
        {

            return Buytable[idOrder];

        }

        // Remove an Order from BuyTable 
        public void RemoveBuyOrder(Order order)
        {
            if (Buytable.Contains(order))
            {
                Buytable.Remove(order);
            }

        }
        // Add an OrderBuy to BuyTable 
        public  void AddBuyOrder(Order _order)
        {


            if (_order.OperationType == Operation_type.BUY && !Buytable.Contains(_order) )
            {
                Buytable.Add(_order);

            }
        }

       
    }
}