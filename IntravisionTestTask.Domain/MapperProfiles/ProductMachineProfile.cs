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
            CreateMap<ProductMachineToCreate, ProductMachine>();
            CreateMap<ProductMachineToUpdate, ProductMachine>();
            CreateMap<ProductMachine, ProductMachineToGet>();
            CreateMap<ProductMachine[], ProductMachineToGet[]>();
        }
    }
}
