using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntravisionTestTask.Domain.Entities
{
    public class ProductSlot : IEntity<Guid>
    {
        [Required]
        public Guid Id { get; set; }

        [InverseProperty(nameof(Entities.ProductMachine.Id))]
        public Guid? ProductMachineId { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(200)]
        public string? ImageUrl { get; set; }

        public ICollection<Product> Products { get; set; }
        public ProductMachine ProductMachine { get; set; }
    }
}