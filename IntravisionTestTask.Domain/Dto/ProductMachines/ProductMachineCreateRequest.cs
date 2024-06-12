using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductMachineCreateRequest : ICreateRequest<ProductMachine, Guid>
    {
        public int? Capacity { get; set; }
    }
}