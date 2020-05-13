using Ecommerce.Core.CQRS;
using System;

namespace Sales.Interfaces.Commands
{
    public class AcceptOrderCommand : ICommand
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
