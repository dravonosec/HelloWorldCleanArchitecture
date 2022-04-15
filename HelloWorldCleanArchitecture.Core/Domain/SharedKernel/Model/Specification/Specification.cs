using System.Linq.Expressions;

namespace Ftsoft.Domain.Specification
{
    public class Specification<TEntity> : ISpecification<TEntity> where TEntity : Entity, IAggregateRoot
    {
        private readonly Expression<Func<TEntity, bool>> _expression;

        public Specification(Expression<Func<TEntity, bool>> expression)
        {
            _expression = expression;
        }
        public Expression<Func<TEntity, bool>> IsSatisfiedBy()
        {
            return _expression;
        }

        public static ISpecification<TEntity> Empty()
        {
            return new Specification<TEntity>(x => true);
        }

        public static ISpecification<TEntity> Create(Expression<Func<TEntity, bool>> expression)
        {
            return new Specification<TEntity>(expression);
        }
    }
}