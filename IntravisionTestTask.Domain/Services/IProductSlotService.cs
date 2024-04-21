using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Services
{
    public interface IProductSlotService : ICrudService<ProductSlot, Guid, ProductSlotToGet, ProductSlotToCreate, ProductSlotToUpdate>
    {
    }
}