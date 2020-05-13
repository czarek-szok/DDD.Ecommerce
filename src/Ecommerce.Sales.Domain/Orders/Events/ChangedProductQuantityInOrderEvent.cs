using Ecommerce.Core.DDD;
using System;

namespace Sales.Domain.Orders.Events
{
    public class ChangedProductQuantityInOrderEvent : IEvent
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }

        public ChangedProductQuantityInOrderEvent(Guid orderId, Guid productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }
    }
}
