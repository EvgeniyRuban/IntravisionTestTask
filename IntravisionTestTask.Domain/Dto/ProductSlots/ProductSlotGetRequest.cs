using IntravisionTestTask.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductSlotGetRequest : IGetRequest<ProductSlot, Guid>
    {
        [Required]
        public Guid Id { get; set; }
    }
}