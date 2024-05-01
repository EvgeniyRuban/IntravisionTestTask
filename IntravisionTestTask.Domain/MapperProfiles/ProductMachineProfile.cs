using AutoMapper;
using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.MapperProfiles
{
    public class ProductMachineProfile : Profile
    {
        public ProductMachineProfile()
        {
            CreateMap<ProductMachine, ProductMachine>();
            CreateMap<ProductGetRequest, Product>();
            CreateMap<ProductMachineCreateRequest, ProductMachine>();
            CreateMap<ProductMachine, ProductMachineCreateResponse>();
            CreateMap<ProductMachineUpdateRequest, ProductMachine>();
            CreateMap<ProductMachine, ProductMachineGetResponse>();
            CreateMap<ProductMachine[], ProductMachineGetResponse[]>();
        }
    }
}
