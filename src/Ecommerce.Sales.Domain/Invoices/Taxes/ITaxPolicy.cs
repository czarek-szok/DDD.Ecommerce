using Sales.Domain.Orders;

namespace Sales.Domain.Invoices.TaxPolicy
{
    public interface ITaxPolicy
    {
        Tax CalculateTax(Product product, double price);
    }
}
