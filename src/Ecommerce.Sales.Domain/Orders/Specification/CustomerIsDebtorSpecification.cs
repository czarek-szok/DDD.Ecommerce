using Ecommerce.Core.DDD.Specification;

namespace Sales.Domain.Orders.Specification
{
    public class CustomerIsDebtorSpecification : Specification<Order>
    {
        private readonly CustomerOrders _customerOrders;
        public CustomerIsDebtorSpecification(CustomerOrders customerOrders)
        {
            _customerOrders = customerOrders;
        }
        public override SpecificationResult IsSatisfiedBy(Order entity)
        {
            var specificationResult = SpecificationResult.Satisfied();

            if (CustomerIsDebtor(entity))
            {
                specificationResult.IsSatisifed = false;
                specificationResult.Errors.Add($"Customer {entity.Customer.Id} is debtor");
            }

            return specificationResult;
        }

        private bool CustomerIsDebtor(Order order)
        {
            int minOrdersWhenDebtor = 10;
            double minAllowedOrderTotalPriceWhenDebtor = 2000;

            return order.Customer.IsDebtor
                && _customerOrders.Orders.Count <= minOrdersWhenDebtor
                && minAllowedOrderTotalPriceWhenDebtor > 2000;
        }
    }
}
