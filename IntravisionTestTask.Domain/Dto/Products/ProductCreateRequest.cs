using IntravisionTestTask.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductCreateRequest : ICreateRequest<Product, Guid>
    {
        [Required]
        public Guid ProductTypeId { get; set; }

        [Required]
        public string Title { get; set; }
    }
}