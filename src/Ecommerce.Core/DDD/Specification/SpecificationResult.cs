using System;
using System.Collections.Generic;


namespace Ecommerce.Core.DDD.Specification
{
    public class SpecificationResult
    {
        public SpecificationResult()
        {
            Errors = new List<string>();
        }

        public static SpecificationResult Satisfied()
        {
            return new SpecificationResult { IsSatisifed = true };
        }

        public static SpecificationResult NotSatisfied(List<string> errors)
        {
            return new SpecificationResult { IsSatisifed = false, Errors = errors };
        }

        public static SpecificationResult NotSatisfied(string errorCode, params object[] args)
        {
            var result = new SpecificationResult();
            var errorMessage = String.Concat(errorCode, String.Join(", ", args));

            result.Errors.Add(errorMessage);

            result.IsSatisifed = false;

            return result;
        }

        public bool IsSatisifed { get; set; }
        public List<string> Errors { get; private set; }
    }
}
