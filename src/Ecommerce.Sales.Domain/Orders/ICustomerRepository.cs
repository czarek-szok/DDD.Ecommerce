using System;

namespace Sales.Domain.Orders
{
    public interface ICustomerRepository
    {
        Customer Get(Guid customerId);
        CustomerOrders GetOrders(Guid customerId);
    }
}
