using System;
using Engine;
namespace Markets
{
    public class MarketOrder
    {

        private Operation_type operationType;
        private int price;
        private Devise devise;
        private Quantity quantity;
        public MarketOrder()
        {
        }
        public int Price { get => price; set => price = value; }
        public Devise Devise { get => devise; set => devise = value; }
        public Quantity Quantity { get => quantity; set => quantity = value; }
        public Operation_type OperationType { get => operationType; set => operationType = value; }
    }
}
