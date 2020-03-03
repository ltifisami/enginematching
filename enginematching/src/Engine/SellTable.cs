using System.Collections;
using System.Collections.Generic;

namespace Engine
{
    public class SellTable
    {

        public static List<IOrder> Selltable = new List<IOrder>();

        public static Dictionary<string, List<IOrder>> SellTables = new Dictionary<string, List<IOrder>>();

        public SellTable()
        {
        }

        public static void AddSellOrderInSellTables(Order _order)
        {
            if (!SellTables.ContainsKey(_order.Ticker))
            {
                List<IOrder> _Selltable = new List<IOrder>
                {
                    _order
                };
                SellTables.Add(_order.Ticker, _Selltable);
            }
            else
            {
                SellTables[_order.Ticker].Add(_order);
            }

        }






    }
}


