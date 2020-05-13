namespace Sales.Domain.Orders.Policies.Discount
{
    public class StandardDiscountPolicy : IDiscountPolicy
    {
        private readonly double _discount;
        private readonly double _minimumQuantity;
        private readonly CustomerOrders _customerOrders;
        public StandardDiscountPolicy(CustomerOrders customerOrders, int minimumQuantity, double discount)
        {
            _discount = discount / 100;
            _minimumQuantity = minimumQuantity;
            _customerOrders = customerOrders;
        }

        public double Calculate(double price, int quantity)
        {
            if (_customerOrders.GetTotalPriceFromAllOrders() > _minimumQuantity)
            {
                var discount = price * quantity * _discount;
                return price * quantity - discount;
            }


            return price * quantity;
        }
    }
}

