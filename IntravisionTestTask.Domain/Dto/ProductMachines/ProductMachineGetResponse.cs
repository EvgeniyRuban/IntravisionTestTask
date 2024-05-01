using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductMachineGetResponse : IGetResponse<ProductMachine, Guid>
    {
        public Guid Id { get; set; }
        public int Capacity { get; set; }
        public ICollection<ProductSlotGetResponse> ProductSlots { get; set; }
    }
}