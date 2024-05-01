using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Entities
{
    public class ProductMachine : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public int Capacity { get; set; }
        public ICollection<ProductSlot> ProductSlots { get; set; }
    }
}