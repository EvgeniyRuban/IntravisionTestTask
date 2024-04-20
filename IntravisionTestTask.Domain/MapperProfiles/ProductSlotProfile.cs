using AutoMapper;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.MapperProfiles
{
    public class ProductSlotProfile : Profile
    {
        public ProductSlotProfile()
        {
            CreateMap<ProductSlot, ProductSlot>();
        }
    }
}
