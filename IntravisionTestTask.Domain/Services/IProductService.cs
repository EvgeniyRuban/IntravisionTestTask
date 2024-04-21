using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Services
{
    public interface IService<TEntity, TKey>
        where TKey : struct
        where TEntity : class, IEntity<TKey>
    {
        //CRUD
        Task<>
    }
}
