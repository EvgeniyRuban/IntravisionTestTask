using IntravisionTestTask.Domain.Entities;
using IntravisionTestTask.Domain.Repositories;

public interface IProductTypeRepository : ICrudRepository<ProductType, Guid>
{
}
