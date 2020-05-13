
using Ecommerce.Core.DDD;

namespace Sales.Domain.Invoices
{
    public class Tax : IValueObject
    {
        public double Amount { get; private set; }
        public string Description { get; private set; }

        public Tax(double amount, string description)
        {
            Amount = amount;
            Description = description;
        }
    }
}
