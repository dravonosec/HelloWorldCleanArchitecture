using Ftsoft.Domain;
using Ftsoft.Domain.Specification;

namespace Ftsoft.Storage
{
    public abstract class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        public virtual bool ReadOnly { get; set; }
        public abstract Task<TEntity> FindAsync(long id, CancellationToken cancellationToken);
        public abstract Task<TEntity[]> ListAsync(CancellationToken cancellationToken);
        public abstract Task<TEntity[]> ListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
        public abstract Task<TEntity> SingleAsync(CancellationToken cancellationToken);
        public abstract Task<TEntity> SingleAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
        public abstract Task<TEntity> SingleOrDefaultAsync(CancellationToken cancellationToken);
        public abstract Task<TEntity> SingleOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
        public abstract Task<TEntity> FirstAsync(CancellationToken cancellationToken);
        public abstract Task<TEntity> FirstAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
        public abstract Task<TEntity> FirstOrDefaultAsync(CancellationToken cancellationToken);
        public abstract Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
        public abstract Task<int> CountAsync(CancellationToken cancellationToken);
        public abstract Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
        public abstract Task<long> LongCountAsync(CancellationToken cancellationToken);
        public abstract Task<long> LongCountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
        public abstract Task<TResult[]> Query<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> query, CancellationToken cancellationToken);
    }
}