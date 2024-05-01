using AutoMapper;
using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, Product>();
            CreateMap<ProductGetRequest, Product>();
            CreateMap<ProductCreateRequest, Product>();
            CreateMap<ProductUpdateRequest, Product>();
            CreateMap<Product, ProductCreateResponse>();
            CreateMap<Product, ProductGetResponse>();
            CreateMap<Product[], ProductGetResponse[]>();
        }
    }
}
