using Sales.Domain.Orders;

namespace Sales.Domain.Invoices
{
    public class InvoiceLine
    {
        public Product Product { get; }
        public int Quantity { get; }
        public double NettPrice { get; }
        public double GrossPrice { get; }
        public Tax Tax { get; }

        public InvoiceLine(Product product, int quantity, double nettPrice, Tax tax)
        {
            Product = product;
            Quantity = quantity;
            NettPrice = nettPrice;
            Tax = tax;
            GrossPrice = nettPrice + tax.Amount;
        }
    }
}
