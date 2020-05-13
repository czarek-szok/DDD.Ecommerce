using Sales.Domain.Orders;

namespace Sales.Domain.Invoices.TaxPolicy
{
    public class ForeignerTaxPolicy : ITaxPolicy
    {
        private double _defaultTax = 0.1;
        public Tax CalculateTax(Product product, double price)
        {
            var foreignerTaxAmount = price * _defaultTax;
            return new Tax(foreignerTaxAmount, "Foreigner tax");
        }
    }
}
