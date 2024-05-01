using IntravisionTestTask.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductUpdateRequest : IUpdateRequest<Product, Guid>
    {
        [Required]
        public Guid Id { get; set; }
        public Guid? ProductTypeId { get; set; }
    }
}