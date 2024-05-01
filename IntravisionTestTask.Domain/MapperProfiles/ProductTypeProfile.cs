using AutoMapper;
using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.MapperProfiles
{
    public class ProductTypeProfile : Profile
    {
        public ProductTypeProfile()
        {
            CreateMap<ProductType, ProductType>();
            CreateMap<ProductTypeGetRequest, ProductType>();
            CreateMap<ProductTypeCreateRequest, ProductType>();
            CreateMap<ProductTypeUpdateRequest, ProductType>();
            CreateMap<ProductType, ProductTypeCreateResponse>();
            CreateMap<ProductType, ProductTypeGetResponse>();
            CreateMap<ProductType[], ProductTypeGetResponse[]>();
        }
    }
}