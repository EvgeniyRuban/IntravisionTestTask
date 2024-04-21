using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Repositories
{
    public interface IProductTypeRepository : ICrudRepository<ProductType, Guid>
    {
    }
}