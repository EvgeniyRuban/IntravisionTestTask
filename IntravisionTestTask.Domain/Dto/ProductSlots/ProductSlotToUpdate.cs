using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductSlotToUpdate : IUpdateDto<ProductSlot, Guid>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid ProductMachineId { get; set; }
        public int Capacity { get; set; }
    }
}