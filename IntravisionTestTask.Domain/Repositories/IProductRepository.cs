using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Repositories
{
    public interface IProductRepository : ICrudRepository<Product, Guid>
    {
    }
}