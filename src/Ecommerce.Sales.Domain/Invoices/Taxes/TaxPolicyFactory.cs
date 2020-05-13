using Sales.Domain.Orders;

namespace Sales.Domain.Invoices.TaxPolicy
{
    public class TaxPolicyFactory
    {
        public ITaxPolicy CreateTaxPolicy(Customer customer)
        {
            if (customer.IsForeigner)
                return new ForeignerTaxPolicy();

            return new StandardTaxPolicy();
        }
    }
}
