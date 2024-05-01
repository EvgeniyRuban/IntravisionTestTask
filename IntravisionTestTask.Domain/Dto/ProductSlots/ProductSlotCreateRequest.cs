using IntravisionTestTask.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductSlotCreateRequest : ICreateRequest<ProductSlot, Guid>
    {
        public Guid? ProductMachineId { get; set; }
        public string? ImageUrl { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}