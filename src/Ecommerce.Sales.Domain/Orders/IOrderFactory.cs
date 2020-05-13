namespace Sales.Domain.Orders
{
    public interface IOrderFactory
    {
        Order Create(Customer customer);
    }
}