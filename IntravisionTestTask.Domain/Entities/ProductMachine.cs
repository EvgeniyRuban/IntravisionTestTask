using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntravisionTestTask.Domain.Entities
{
    public class ProductMachine : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        public ICollection<ProductSlot> ProductSlots { get; set; }
    }
}