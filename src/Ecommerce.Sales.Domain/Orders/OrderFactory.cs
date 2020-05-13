using Sales.Application.Exceptions;


namespace Sales.Domain.Orders
{
    public class OrderFactory : IOrderFactory
    {
        public Order Create(Customer customer)
        {
            if (customer.IsDebtor)
                throw new CustomerIsDebtorException(customer.Id);

            Order order = new Order(customer);
            return order;
        }
    }
}
