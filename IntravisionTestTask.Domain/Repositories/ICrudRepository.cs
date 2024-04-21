using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Repositories
{
    public interface ICrudRepository<TEntity, TKey>
        where TKey : struct
        where TEntity : class, IEntity<TKey>
    {
        Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity?> Get(TKey id, CancellationToken cancellationToken);
        Task<ICollection<TEntity>> GetAll(CancellationToken cancellationToken);
        Task Update(TEntity entityToUpdate, CancellationToken cancellationToken);
        Task Delete(TKey id, CancellationToken cancellationToken);
    }
}