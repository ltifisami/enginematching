using System;
using System.Collections.Generic;

namespace Engine
{
    public interface IOrder
    {

        string Ticker { get; set ; }
        Operation_type OperationType { get; set; }
        Order_type OrderTrade { get; set; }
        int OrderQuantity { get; set; }
        int OrderPrice { get; set; }
        Devise Devise { get; set; }
        DateTime DateCreateOrder { get; set; }
        DateTime DateEndOrder { get; set; }
        string Country { get; set; }
        string OrderId { get; set; }
        Statue Statue { get; set; }

        Order_type GetOrderType(string current_order);
         Operation_type GetOperationType(string current_order);
         Devise GetDevise(string current_order);
         Order CreateOrder(string[] stdInputArgumentsArray);
         List<IOrder> GetOrders(DateTime start, DateTime end);
         string ConvertDeviseToString(IOrder order);


    }
}
