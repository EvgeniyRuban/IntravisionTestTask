using IntravisionTestTask.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductGetRequest : IGetRequest<Product, Guid>
    {
        [Required]
        public Guid Id { get; set; }    
    }
}