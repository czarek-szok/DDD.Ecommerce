using Ecommerce.Core.DDD.Specification;
using System;

namespace Sales.Domain.Orders.Specification
{
    public class OrderIsOverduedSpecification : Specification<Order>
    {
        public override SpecificationResult IsSatisfiedBy(Order entity)
        {
            var specificationResult = SpecificationResult.Satisfied();

            if (IsOverdued(entity))
            {
                specificationResult.IsSatisifed = false;
                specificationResult.Errors.Add($"Order {entity.Id} is overdued");
            }

            return specificationResult;
        }

        private bool IsOverdued(Order order)
        {
            return order.CreateDate > DateTime.Today.AddMonths(-1);
        }
    }
}
