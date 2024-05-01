using IntravisionTestTask.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductTypeGetRequest : IGetRequest<ProductType, Guid>
    {
        [Required]
        public Guid Id { get; set; }
    }
}