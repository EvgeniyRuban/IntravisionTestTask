using IntravisionTestTask.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductTypeCreateRequest : ICreateRequest<ProductType, Guid>
    {
        [Required]
        public string Title { get; set; }
    }
}
