using Ecommerce.Core.CQRS;
using Sales.Domain.Invoices;
using Sales.Domain.Invoices.TaxPolicy;
using Sales.Domain.Orders;
using Sales.Interfaces.Commands;


namespace Sales.Application.CommandHandlers
{
    public class IssueInvoiceCommandHandler : ICommandHandler<IssueInvoiceCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly InvoiceService _invoiceService;
        private readonly TaxPolicyFactory _taxPolicyFactory;

        public IssueInvoiceCommandHandler(IOrderRepository orderRepository,
                                          IInvoiceRepository invoiceRepository,
                                          InvoiceService invoiceService,
                                          TaxPolicyFactory taxPolicyFactory)
        {
            _orderRepository = orderRepository;
            _invoiceService = invoiceService;
            _invoiceRepository = invoiceRepository;
            _taxPolicyFactory = taxPolicyFactory;
        }

        public void Handle(IssueInvoiceCommand command)
        {
            var order = _orderRepository.Get(command.OrderId);

            var taxPolicy = _taxPolicyFactory.CreateTaxPolicy(order.Customer);

            var invoice = _invoiceService.CreateInvoice(order, taxPolicy);

            _invoiceRepository.Save(invoice);
        }
    }
}
