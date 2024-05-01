using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Services
{
    public interface IProductMachineService : ICrudService<ProductMachine, Guid, ProductMachineGetRequest, 
        ProductMachineGetResponse, ProductMachineCreateRequest, ProductMachineCreateResponse,ProductMachineUpdateRequest>
    {
        Task AddProductSlotById(Guid id, Guid productSlotId, CancellationToken cancellationToken);
        Task Clear(Guid id, CancellationToken cancellationToken);
    }
}