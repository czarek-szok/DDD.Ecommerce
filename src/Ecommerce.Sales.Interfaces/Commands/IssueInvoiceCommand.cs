using Ecommerce.Core.CQRS;
using System;


namespace Sales.Interfaces.Commands
{
    public class IssueInvoiceCommand : ICommand
    {
        public Guid OrderId { get; set; }

        public event EventHandler CanExecuteChanged;
    }
}
