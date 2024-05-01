using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Entities
{
    public class Product : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? ProductTypeId { get; set; }
        public Guid? ProductSlotId { get; set; }
        public string Title { get; set; }

        public ProductSlot ProductSlot { get; set; }
        public ProductType ProductType { get; set; }
    }
}