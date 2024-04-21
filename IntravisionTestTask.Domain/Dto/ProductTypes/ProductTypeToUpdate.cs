using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductTypeToUpdate : IUpdateDto<ProductType, Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
    }
}