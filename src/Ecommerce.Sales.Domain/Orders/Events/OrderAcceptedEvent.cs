using Ecommerce.Core.DDD;
using System;

namespace Sales.Domain.Orders.Events
{
    public class OrderAcceptedEvent : IEvent
    {
        public Guid OrderId { get; private set; }
        public OrderAcceptedEvent(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
