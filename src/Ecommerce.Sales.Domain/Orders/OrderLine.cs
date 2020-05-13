using Sales.Domain.Orders.Policies.Discount;

namespace Sales.Domain.Orders
{
    public class OrderLine
    {
        public int Quantity { get; private set; }
        public Product Product { get; private set; }
        public double TotalPrice { get; private set; }
        public double TotalPriceWithDiscount { get; private set; }

        public OrderLine(Product product, int quantity, IDiscountPolicy discountPolicy)
        {
            Quantity = quantity;
            Product = product;
            CalculatePrice(discountPolicy);
        }

        public void IncreaseQuantity(int quantity, IDiscountPolicy discountPolicy)
        {
            Quantity += quantity;
            CalculatePrice(discountPolicy);
        }

        private void CalculatePrice(IDiscountPolicy discountPolicy)
        {
            TotalPrice = Product.Price * Quantity;

            if (IsDiscountApplied(discountPolicy))
            {
                TotalPriceWithDiscount = discountPolicy.Calculate(Product.Price, Quantity);
            }
            else
            {
                TotalPriceWithDiscount = TotalPrice;
            }
        }

        private bool IsDiscountApplied(IDiscountPolicy discountPolicy)
        {
            return discountPolicy != null;
        }
    }
}
