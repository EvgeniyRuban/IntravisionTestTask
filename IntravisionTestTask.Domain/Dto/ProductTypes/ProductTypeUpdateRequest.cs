using IntravisionTestTask.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductTypeUpdateRequest : IUpdateRequest<ProductType, Guid>
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;
    }
}