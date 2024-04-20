using IntravisionTestTask.Domain.Entities;
using IntravisionTestTask.Domain.Repositories;

public interface IProductRepository : ICrudRepository<Product, Guid>
{
}
