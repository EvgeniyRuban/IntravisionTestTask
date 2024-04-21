using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductTypeToCreate : ICreateDto<ProductType, Guid>
    {
        public string Title { get; set; }
    }
}
