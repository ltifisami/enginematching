using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class BuyTable
    {
        public static List<IOrder> Buytable = new List<IOrder>();
        public static Dictionary<string, List<IOrder>> BuyTables = new Dictionary<string, List<IOrder>>();

        public BuyTable()
        {
        }

        public static void AddBuyOrderInBuyTables(Order _order)
        {
            if (!BuyTables.ContainsKey(_order.Ticker))
            {
                List<IOrder> _Buytable = new List<IOrder>
                {
                    _order
                };
                BuyTables.Add(_order.Ticker, _Buytable);
            }
            else
            {
                BuyTables[_order.Ticker].Add(_order);
            }
        }





    }
}