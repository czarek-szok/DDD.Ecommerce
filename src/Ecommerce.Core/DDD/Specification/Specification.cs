namespace Ecommerce.Core.DDD.Specification
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract SpecificationResult IsSatisfiedBy(T entity);

        public ISpecification<T> And(ISpecification<T> otherEntity)
        {
            return new AndSpecification<T>(this, otherEntity);
        }

        public ISpecification<T> Or(ISpecification<T> otherEntity)
        {
            return new OrSpecification<T>(this, otherEntity);
        }

    }
}
