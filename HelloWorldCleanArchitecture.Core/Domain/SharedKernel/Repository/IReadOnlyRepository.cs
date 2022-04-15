﻿using Ftsoft.Domain;
using Ftsoft.Domain.Specification;

namespace Ftsoft.Storage
{
    public interface IReadOnlyRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        bool ReadOnly { get; }
        Task<TEntity> FindAsync(long id, CancellationToken cancellationToken);
        Task<TEntity[]> ListAsync(CancellationToken cancellationToken);
        Task<TEntity[]> ListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
        Task<TEntity> SingleAsync(CancellationToken cancellationToken);

        Task<TEntity> SingleAsync(ISpecification<TEntity> specification,
            CancellationToken cancellationToken);
        Task<TEntity> SingleOrDefaultAsync(CancellationToken cancellationToken);
        Task<TEntity> SingleOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
        Task<TEntity> FirstAsync(CancellationToken cancellationToken);
        Task<TEntity> FirstAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
        Task<TEntity> FirstOrDefaultAsync(CancellationToken cancellationToken);
        Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
        Task<int> CountAsync(CancellationToken cancellationToken);
        Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
        Task<long> LongCountAsync(CancellationToken cancellationToken);
        Task<long> LongCountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
        Task<TResult[]> Query<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> query,
            CancellationToken cancellationToken);
    }
}