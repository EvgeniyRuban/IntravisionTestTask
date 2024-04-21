using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Repositories
{
    public interface IProductMachineRepository : ICrudRepository<ProductMachine, Guid>
    {
    }
}