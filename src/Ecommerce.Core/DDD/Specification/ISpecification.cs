
namespace Ecommerce.Core.DDD.Specification
{
    public interface ISpecification<T>
    {
        SpecificationResult IsSatisfiedBy(T entity);
        ISpecification<T> And(ISpecification<T> otherEntity);
        ISpecification<T> Or(ISpecification<T> otherEntity);
    }
}
