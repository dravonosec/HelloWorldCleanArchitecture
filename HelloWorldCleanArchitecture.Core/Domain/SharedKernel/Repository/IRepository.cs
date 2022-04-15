using Ftsoft.Domain;

namespace Ftsoft.Storage
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
        IUnitOfWork UnitOfWork { get; }
    }
}