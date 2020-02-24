namespace Engine
{
    public class SettlementTable
    {
        private CountryList delivryCountry;
        private string delivryAddress;
        private string ticker;
        public CountryList DelivryCountry { get => delivryCountry; set => delivryCountry = value; }
        public string DelivryAddress { get => delivryAddress; set => delivryAddress = value; }
        public string Ticker { get => ticker; set => ticker = value; }

        public SettlementTable()
        {
            Ticker = Ticker;
            DelivryCountry = delivryCountry;
            DelivryAddress = delivryAddress;
        }





    }

}
