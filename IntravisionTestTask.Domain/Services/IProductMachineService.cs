using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Services
{
    public interface IProductMachineService : ICrudService<ProductMachine, Guid, ProductMachineToGet, ProductMachineToCreate, ProductMachineToUpdate>
    {
    }
}