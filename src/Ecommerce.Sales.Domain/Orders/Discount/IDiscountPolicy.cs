namespace Sales.Domain.Orders.Policies.Discount
{
    public interface IDiscountPolicy
    {
        double Calculate(double price, int quantity);
    }
}
