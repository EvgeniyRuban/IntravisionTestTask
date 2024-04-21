using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductSlotToGet : IGetDto<ProductSlot, Guid>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Capacity { get; set; }
    }
}