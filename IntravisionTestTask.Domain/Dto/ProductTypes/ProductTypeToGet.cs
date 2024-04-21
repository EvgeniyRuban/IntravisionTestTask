using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductTypeToGet : IGetDto<ProductType, Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}