using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntravisionTestTask.Domain.Entities
{
    public class Product : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [InverseProperty(nameof(Entities.ProductType.Id))]
        public Guid ProductTypeId { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;

        public ProductType ProductType { get; set; }
    }
}