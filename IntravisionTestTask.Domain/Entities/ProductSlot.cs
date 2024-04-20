using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntravisionTestTask.Domain.Entities
{
    public class ProductSlot : IEntity<Guid>
    {
        public Guid Id { get; set; }

        [Required]
        [InverseProperty(nameof(Entities.Product.Id))]
        public Guid ProductId { get; set; }
        [Required]
        public int Capacity { get; set; }

        public Product Product { get; set; } = null!;
    }
}