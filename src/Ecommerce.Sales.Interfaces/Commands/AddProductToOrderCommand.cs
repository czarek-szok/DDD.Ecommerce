using Ecommerce.Core.CQRS;
using System;

namespace Sales.Interfaces.Commands
{
    public class AddProductToOrderCommand : ICommand
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}