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
            CreateMap<ProductToCreate, Product>();
            CreateMap<ProductToUpdate, Product>();
            CreateMap<Product, ProductToGet>();
            CreateMap<Product[], ProductToGet[]>();
        }
    }
}
