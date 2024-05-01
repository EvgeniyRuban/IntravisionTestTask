using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Services
{
    public interface IProductService : ICrudService<Product, Guid, ProductGetRequest, ProductGetResponse, 
        ProductCreateRequest, ProductCreateResponse, ProductUpdateRequest>
    {
    }
}