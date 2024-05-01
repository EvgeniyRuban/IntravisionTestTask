using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Repositories
{
    public interface IProductMachineRepository : ICrudRepository<ProductMachine, Guid>
    {
        Task AddProductSlotById(Guid id, Guid productSlotId, CancellationToken cancellationToken);
        Task Clear(Guid id, CancellationToken cancellationToken);
    }
}