using Sales.Domain.Orders;
using System.Collections.Generic;

namespace Sales.Domain.Invoices
{
    public class Invoice
    {
        public List<InvoiceLine> Lines { get; private set; }
        public Customer Customer { get; private set; }
        public double NettPrice { get; private set; }
        public double GrossPrice { get; private set; }


        public Invoice(Customer customer)
        {
            Customer = customer;
            Lines = new List<InvoiceLine>();
        }
        public void AddLine(InvoiceLine line)
        {
            Lines.Add(line);
            NettPrice += line.NettPrice;
            GrossPrice += line.GrossPrice;
        }
    }
}
