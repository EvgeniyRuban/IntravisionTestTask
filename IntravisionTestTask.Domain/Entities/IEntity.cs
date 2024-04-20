using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Entities
{
    public interface IEntity<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
    }

    public class ProductMachine : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public ICollection<ProductSlot> ProductSlots { get; set; }
    }
}