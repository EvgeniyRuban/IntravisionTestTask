using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductTypeCreateResponse : ICreateResponse<ProductType, Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
