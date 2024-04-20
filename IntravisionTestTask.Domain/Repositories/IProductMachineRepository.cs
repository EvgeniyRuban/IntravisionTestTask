using IntravisionTestTask.Domain.Entities;
using IntravisionTestTask.Domain.Repositories;

public interface IProductMachineRepository :ICrudRepository<ProductMachine, Guid>
{
}