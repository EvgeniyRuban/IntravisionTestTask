using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public interface IUpdateRequest<TEntity, TKey> : IDto<TEntity, TKey>
        where TKey : struct
        where TEntity : class, IEntity<TKey>
    {
    }
}