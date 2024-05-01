using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Repositories
{
    public interface IProductSlotRepository : ICrudRepository<ProductSlot, Guid>
    {
        Task AddProductById(Guid id, Guid productId, CancellationToken cancellationToken);
        Task Clear(Guid id, CancellationToken cancellationToken);
    }
}