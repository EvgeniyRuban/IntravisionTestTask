using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductMachineCreateResponse : ICreateResponse<ProductMachine, Guid>
    {
        public Guid Id { get; set; }
        public int Capacity { get; set; }
    }
}