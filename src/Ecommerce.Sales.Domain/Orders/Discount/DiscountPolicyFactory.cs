namespace Sales.Domain.Orders.Policies.Discount
{
    public class DiscountPolicyFactory : IDiscountPolicyFactory
    {
        private readonly CustomerOrders _customerOrders;
        private int _minQuantity = 1000;
        private double _standardDiscountPercentage = 5;
        private double _vipDiscountPercentage = 10;

        public DiscountPolicyFactory(CustomerOrders customerOrders)
        {
            _customerOrders = customerOrders;
        }

        public IDiscountPolicy Create(Customer customer)
        {
            IDiscountPolicy discountPolicy;

            if (customer.IsVip)
            {
                discountPolicy = new CustomerVipDiscountPolicy(_vipDiscountPercentage);
            }
            else
            {
                discountPolicy = new StandardDiscountPolicy(_customerOrders, _minQuantity, _standardDiscountPercentage);
            }

            return discountPolicy;
        }
    }
}
