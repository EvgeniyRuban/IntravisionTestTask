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
            CreateMap<ProductTypeToCreate, ProductType>();
            CreateMap<ProductTypeToUpdate, ProductType>();
            CreateMap<ProductType, ProductTypeToGet>();
            CreateMap<ProductType[], ProductTypeToGet[]>();
        }
    }
}