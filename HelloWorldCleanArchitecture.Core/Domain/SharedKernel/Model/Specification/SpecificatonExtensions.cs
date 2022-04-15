using Ftsoft.Domain.Specification;
using Mono.Linq.Expressions;

namespace Ftsoft.Domain.Extensions.Specification
{
    public static class SpecificationExtensions
    {
        public static ISpecification<TEntity> And<TEntity>(this ISpecification<TEntity> specLeft,
            ISpecification<TEntity> specRight) where TEntity : Entity, IAggregateRoot
        {
            if (specLeft == null)
            {
                return specRight;
            }

            var specLeftExpresion = specLeft.IsSatisfiedBy();
            var specRightExpression = specRight.IsSatisfiedBy();

            var andAlsoExpression = PredicateBuilder.AndAlso(specLeftExpresion, specRightExpression);

            return new Specification<TEntity>(andAlsoExpression);
        }

        public static ISpecification<TEntity> Or<TEntity>(this ISpecification<TEntity> specLeft,
            ISpecification<TEntity> specRight) where TEntity : Entity, IAggregateRoot
        {
            if (specLeft == null)
            {
                return specRight;
            }

            var specLeftExpresion = specLeft.IsSatisfiedBy();
            var specRightExpression = specRight.IsSatisfiedBy();
            
            var orExpression = PredicateBuilder.OrElse(specLeftExpresion, specRightExpression);
            return new Specification<TEntity>(orExpression);
        }

        public static ISpecification<TEntity> Not<TEntity>(ISpecification<TEntity> specification)
            where TEntity : Entity, IAggregateRoot
        {
            var notExpression = PredicateBuilder.Not(specification.IsSatisfiedBy());
            return new Specification<TEntity>(notExpression);
        }
    }
}