using AutoMapper;
using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.MapperProfiles
{
    public class ProductSlotProfile : Profile
    {
        public ProductSlotProfile()
        {
            CreateMap<ProductSlot, ProductSlot>()
                .ForMember(dest => dest.ProductMachineId, opt => opt
                    .Condition(src => src.ProductMachineId != default || src.ProductMachineId != null))
                .ForMember(dest => dest.ImageUrl, opt => opt
                    .Condition(src => !string.IsNullOrWhiteSpace(src.ImageUrl)));

            CreateMap<ProductSlotGetRequest, ProductSlot>();
            CreateMap<ProductSlotCreateRequest, ProductSlot>();
            CreateMap<ProductSlotUpdateRequest, ProductSlot>();
            CreateMap<ProductSlot, ProductSlotCreateResponse>();
            CreateMap<ProductSlot, ProductSlotGetResponse>();
            CreateMap<ProductSlot[], ProductSlotGetResponse[]>();
        }
    }
}
