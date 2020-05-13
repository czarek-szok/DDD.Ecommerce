using Ecommerce.Core.DDD;
using System;

namespace Sales.Domain.Orders.Events
{
    public class ProductAddedToOrder : IEvent
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }

        public ProductAddedToOrder(Guid orderId, Guid productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }
    }
}
