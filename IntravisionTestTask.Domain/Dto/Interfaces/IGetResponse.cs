using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public interface IGetResponse<TEntity, TKey> : IResponse<TEntity, TKey>
        where TKey : struct
        where TEntity : class, IEntity<TKey>
    {
    }
}