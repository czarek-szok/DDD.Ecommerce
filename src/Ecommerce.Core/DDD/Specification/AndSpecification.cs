using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Core.DDD.Specification
{
    public class AndSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _a;
        private readonly ISpecification<T> _b;

        public AndSpecification(ISpecification<T> a, ISpecification<T> b)
        {
            _a = a;
            _b = b;
        }

        public override SpecificationResult IsSatisfiedBy(T entity)
        {
            var result = new SpecificationResult();
            var results = new List<SpecificationResult>();

            var resultA = _a.IsSatisfiedBy(entity);
            results.Add(resultA);

            var resultB = _b.IsSatisfiedBy(entity);
            results.Add(resultB);

            result.IsSatisifed = results.All(spec => spec.IsSatisifed);

            if (!result.IsSatisifed)
            {
                result.Errors.AddRange(results.SelectMany(x => x.Errors));
            }

            return result;
        }
    }
}
