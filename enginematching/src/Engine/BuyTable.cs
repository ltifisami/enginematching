using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class BuyTable
    {

       
        private static List<Order> buytable = new List<Order>();
        public static List<Order> Buytable { get => buytable; set => buytable = value; }




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
        public static Order GetBuyOrderByOrderId(int idOrder)
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

        //Return a BuyTable by Ticker 
        public static List<Order> GetBuyTableByTicker(string _Ticker)
        {
            List<Order> Orderlist = new List<Order>();
            foreach (var buyOrder in Buytable)
            {
                if (buyOrder.Ticker == _Ticker)
                {
                    Orderlist.Add(buyOrder);
                }

            }
            return Orderlist;

        }


        // Return List of BuyTicker from Buytable

        public static List<string> ListBuyTicker()
        {
            List<string> listTicker = new List<string>();
            foreach (var order in Buytable)
            {
                if (!listTicker.Contains(order.Ticker))
                    listTicker.Add(order.Ticker);
            }
            return listTicker;
        }


    }
}