using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductSlotToCreate : ICreateDto<ProductSlot, Guid>
    {
        public Guid ProductId { get; set; }
        public int Capacity { get; set; }
    }
}