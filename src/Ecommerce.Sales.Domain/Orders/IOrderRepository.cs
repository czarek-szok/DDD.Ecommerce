using System;

namespace Sales.Domain.Orders
{
    public interface IOrderRepository
    {
        CustomerOrders GetCustomerOrders(Guid customerId);
        Order Get(Guid orderId);
        void Save(Order order);
    }
}
