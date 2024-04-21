using AutoMapper;
using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.MapperProfiles
{
    public class ProductSlotProfile : Profile
    {
        public ProductSlotProfile()
        {
            CreateMap<ProductSlot, ProductSlot>();
            CreateMap<ProductSlotToCreate, ProductSlot>();
            CreateMap<ProductSlotToUpdate, ProductSlot>();
            CreateMap<ProductSlot, ProductSlotToGet>();
            CreateMap<ProductSlot[], ProductSlotToGet[]>();
        }
    }
}
