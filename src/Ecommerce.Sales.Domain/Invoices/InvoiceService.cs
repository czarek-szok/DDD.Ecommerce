using Sales.Domain.Invoices.TaxPolicy;
using Sales.Domain.Orders;


namespace Sales.Domain.Invoices
{
    public class InvoiceService
    {
        public Invoice CreateInvoice(Order order, ITaxPolicy taxPolicy)
        {
            Invoice invoice = new Invoice(order.Customer);

            foreach (var orderLine in order.OrderLines)
            {
                Tax tax = taxPolicy.CalculateTax(orderLine.Product, orderLine.TotalPriceWithDiscount);
                InvoiceLine line = new InvoiceLine(orderLine.Product, orderLine.Quantity, orderLine.TotalPriceWithDiscount, tax);

                invoice.AddLine(line);
            }

            return invoice;
        }
    }
}
