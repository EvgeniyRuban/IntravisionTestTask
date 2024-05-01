using IntravisionTestTask.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductSlotUpdateRequest : IUpdateRequest<ProductSlot, Guid>
    {
        [Required]
        public Guid Id { get; set; }
        public string? ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Capacity { get; set; }
    }
}