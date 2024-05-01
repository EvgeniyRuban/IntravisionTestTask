using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Services
{
    public interface IProductSlotService : ICrudService<ProductSlot, Guid, ProductSlotGetRequest, ProductSlotGetResponse, 
        ProductSlotCreateRequest, ProductSlotCreateResponse, ProductSlotUpdateRequest>
    {
        Task AddProductById(Guid id, Guid productId, CancellationToken cancellationToken);
        Task Clear(Guid id, CancellationToken cancellationToken);
    }
}