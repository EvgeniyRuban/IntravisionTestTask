using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Services
{
    public interface IProductTypeService : ICrudService<ProductType, Guid, ProductTypeGetRequest, 
        ProductTypeGetResponse, ProductTypeCreateRequest, ProductTypeCreateResponse, ProductTypeUpdateRequest>
    {
    }
}