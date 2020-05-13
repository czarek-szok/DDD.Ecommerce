namespace Sales.Domain.Orders
{
    public class CustomerOrder
    {
        public double TotalPrice { get; private set; }
        public double TotalPriceWithDiscount { get; private set; }

        public CustomerOrder()
        {

        }

        public CustomerOrder(double totalPrice, double totalPriceWithDiscount)
        {
            TotalPrice = totalPrice;
            TotalPriceWithDiscount = totalPriceWithDiscount;
        }
    }
}
