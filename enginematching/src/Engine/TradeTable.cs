
using System;
using System.Collections.Generic;
using System.Linq;


namespace Engine
{
    // Class TradeTable contains the Order matched
    public class TradeTable
    {
       private string sellOrderId;
        private Order orderTradeBuy;
        private int orderPriceBuy;
        private Devise deviseBuy;
        private string countryBuy;
        private DateTime dateCreateOrderBuy;
        private DateTime dateEndOrderBuy;
        private int orderQuantityTraded;

        private string buyOrderId;
        private Order orderTradeSell;
        private int orderPriceSell;
        private Devise deviseSell;
        private string countrySell;
        private DateTime dateCreateOrderSell;
        private DateTime dateEndOrderSell;


        public string BuyOrderId { get => buyOrderId; set => buyOrderId = value; }
        public Order OrderTradeBuy { get => orderTradeBuy; set => orderTradeBuy = value; }
        public int OrderPriceBuy { get => orderPriceBuy; set => orderPriceBuy = value; }
        public Devise DeviseBuy { get => deviseBuy; set => deviseBuy = value; }
        public string CountryBuy { get => countryBuy; set => countryBuy = value; }
        public DateTime DateCreateOrderBuy { get => dateCreateOrderBuy; set => dateCreateOrderBuy = value; }
        public DateTime DateEndOrderBuy { get => dateEndOrderBuy; set => dateEndOrderBuy = value; }

        public int OrderQuantityTraded { get => orderQuantityTraded; set => orderQuantityTraded = value; }

        public string SellOrderId { get => sellOrderId; set => sellOrderId = value; }
        public Order OrderTradeSell { get => orderTradeSell; set => orderTradeSell = value; }
        public int OrderPriceSell { get => orderPriceSell; set => orderPriceSell = value; }
        public Devise DeviseSell { get => deviseSell; set => deviseSell = value; }
        public string CountrySell { get => countrySell; set => countrySell = value; }
        public DateTime DateCreateOrderSell { get => dateCreateOrderSell; set => dateCreateOrderSell = value; }
        public DateTime DateEndOrderSell { get => dateEndOrderSell; set => dateEndOrderSell = value; }

        public TradeTable()
        {

            OrderTradeBuy = orderTradeBuy;
            OrderPriceBuy = orderPriceBuy;
            DeviseBuy = deviseBuy;
            CountryBuy = countryBuy;
            DateCreateOrderBuy = dateCreateOrderBuy;
            DateEndOrderBuy = dateEndOrderBuy;

            OrderQuantityTraded = orderQuantityTraded;

            OrderTradeSell = orderTradeSell;
            OrderPriceSell = orderPriceSell;
            DeviseSell = deviseSell;
            CountrySell = countrySell;
            DateCreateOrderSell = dateCreateOrderSell;
            DateEndOrderSell = dateEndOrderSell;

        }


        public static void AddTradeTable(IOrder buyOrder, IOrder sellOrder , int num_traded)
        {
            TradeTable tradeTable = new TradeTable()

            {
                BuyOrderId = buyOrder.OrderId,
                OrderPriceBuy = buyOrder.OrderPrice,
                DeviseBuy = buyOrder.Devise,
                CountryBuy = buyOrder.Country,
                OrderQuantityTraded = num_traded,
                SellOrderId = sellOrder.OrderId,
                OrderPriceSell = sellOrder.OrderPrice,
                DeviseSell = sellOrder.Devise,
                CountrySell = sellOrder.Country
            };

            // Add the _tradeTable in Tradetable 


            Matching.Tradetable.Add(tradeTable);

        }

    }
}
