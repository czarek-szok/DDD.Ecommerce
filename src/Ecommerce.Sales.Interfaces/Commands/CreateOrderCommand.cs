
using Ecommerce.Core.CQRS;
using System;

namespace Sales.Interfaces.Commands
{
    public class CreateOrderCommand : ICommand
    {
        public Guid CustomerId { get; set; }
    }
}
