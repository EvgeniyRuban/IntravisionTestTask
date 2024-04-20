using AutoMapper;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.MapperProfiles
{
    public class ProductMachineProfile : Profile
    {
        public ProductMachineProfile()
        {
            CreateMap<ProductMachine, ProductMachine>();
        }
    }
}
