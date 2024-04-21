using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductMachineToGet : IGetDto<ProductMachine, Guid>
    {
        public Guid Id { get; set; }
    }
}