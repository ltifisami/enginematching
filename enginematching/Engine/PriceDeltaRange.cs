namespace enginematching
{
    // class Price_delta_range
    public class PriceDeltaRange
    {

        private int range1;
        private int range2;
        private Devise devise;
        private float priceDelta;

        public int Range1 { get => range1; set => range1 = value; }
        public int Range2 { get => range2; set => range2 = value; }
        public Devise Devise { get => devise; set => devise = value; }
        public float PriceDelta { get => priceDelta; set => priceDelta = value; }




        //Constructor
        public PriceDeltaRange()
        {
            Devise = devise;
            Range1 = range1;
            Range2 = range2;
            PriceDelta = priceDelta;
        }


    }

}
