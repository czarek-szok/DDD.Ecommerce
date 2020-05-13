using Ecommerce.Core.DDD.Specification;


namespace Sales.Domain.Orders.Specification
{
    public class CustomerIsNotVipSpecification : Specification<Order>
    {
        public override SpecificationResult IsSatisfiedBy(Order entity)
        {
            var specificationResult = SpecificationResult.Satisfied();

            if (!entity.Customer.IsVip)
            {
                specificationResult.IsSatisifed = false;
                specificationResult.Errors.Add($"Customer {entity.Customer.Id} is not VIP customer");
            }

            return specificationResult;
        }
    }
}
