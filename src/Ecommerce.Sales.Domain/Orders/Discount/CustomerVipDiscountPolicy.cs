
namespace Sales.Domain.Orders.Policies.Discount
{
    public class CustomerVipDiscountPolicy : IDiscountPolicy
    {
        private double _discount;

        public CustomerVipDiscountPolicy(double discountPercentage)
        {
            _discount = discountPercentage / 100;
        }

        public double Calculate(double price, int quantity)
        {
            var discount = price * quantity * _discount;
            return price * quantity - discount;
        }
    }
}
