using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public interface ICreateRequest<TEntity, TKey> : IDto<TEntity, TKey>
        where TKey : struct
        where TEntity : class, IEntity<TKey>
    {
    }
}