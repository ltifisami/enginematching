
using System;


namespace enginematching
{
    // Class TradeTable contains the Order matched
    public class TradeTable
    {



        private Order orderTradeBuy;
        private int orderQuantityBuy;
        private int orderPriceBuy;
        private Devise deviseBuy;
        private CountryList countryBuy;
        private DateTime dateCreateOrderBuy;
        private TimeSpan validityTimePeriodeBuy;
        private TimeSpan validityAbsoluteTimeBuy;


        private Order orderTradeSell;
        private int orderQuantitySell;
        private int orderPriceSell;
        private Devise deviseSell;
        private CountryList countrySell;
        private DateTime dateCreateOrderSell;
        private TimeSpan validityTimePeriodeSell;
        private TimeSpan validityAbsoluteTimeSell;

        public Order OrderTradeBuy { get => orderTradeBuy; set => orderTradeBuy = value; }
        public int OrderQuantityBuy { get => orderQuantityBuy; set => orderQuantityBuy = value; }
        public int OrderPriceBuy { get => orderPriceBuy; set => orderPriceBuy = value; }
        public Devise DeviseBuy { get => deviseBuy; set => deviseBuy = value; }
        public CountryList CountryBuy { get => countryBuy; set => countryBuy = value; }
        public DateTime DateCreateOrderBuy { get => dateCreateOrderBuy; set => dateCreateOrderBuy = value; }
        public TimeSpan ValidityTimePeriodeBuy { get => validityTimePeriodeBuy; set => validityTimePeriodeBuy = value; }
        public TimeSpan ValidityAbsoluteTimeBuy { get => validityAbsoluteTimeBuy; set => validityAbsoluteTimeBuy = value; }

        public Order OrderTradeSell { get => orderTradeSell; set => orderTradeSell = value; }
        public int OrderQuantitySell { get => orderQuantitySell; set => orderQuantitySell = value; }
        public int OrderPriceSell { get => orderPriceSell; set => orderPriceSell = value; }
        public Devise DeviseSell { get => deviseSell; set => deviseSell = value; }
        public CountryList CountrySell { get => countrySell; set => countrySell = value; }
        public DateTime DateCreateOrderSell { get => dateCreateOrderSell; set => dateCreateOrderSell = value; }
        public TimeSpan ValidityTimePeriodeSell { get => validityTimePeriodeSell; set => validityTimePeriodeSell = value; }
        public TimeSpan ValidityAbsoluteTimeSell { get => validityAbsoluteTimeSell; set => validityAbsoluteTimeSell = value; }


        public TradeTable()
        {
            OrderTradeBuy = orderTradeBuy;
            OrderQuantityBuy = orderQuantityBuy;
            OrderPriceBuy = orderPriceBuy;
            DeviseBuy = deviseBuy;
            CountryBuy = countryBuy;
            DateCreateOrderBuy = dateCreateOrderBuy;
            ValidityTimePeriodeBuy = validityTimePeriodeBuy;
            ValidityAbsoluteTimeBuy = validityAbsoluteTimeBuy;

            OrderTradeSell = orderTradeSell;
            OrderQuantitySell = orderQuantitySell;
            OrderPriceSell = orderPriceSell;
            DeviseSell = deviseSell;
            CountrySell = countrySell;
            DateCreateOrderSell = dateCreateOrderSell;
            ValidityTimePeriodeSell = validityTimePeriodeSell;
            ValidityAbsoluteTimeSell = validityAbsoluteTimeSell;
        }
    }

}
