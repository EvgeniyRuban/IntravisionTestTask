using IntravisionTestTask.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductSlotGetResponse : IGetResponse<ProductSlot, Guid>
    {
        public Guid Id { get; set; }
        public Guid? ProductMachineId { get; set; }
        public string? ImageUrl { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public ICollection<ProductGetResponse> Products { get; set; }
    }
}