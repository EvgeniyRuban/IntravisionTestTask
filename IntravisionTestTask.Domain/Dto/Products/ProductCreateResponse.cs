using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductCreateResponse : ICreateResponse<Product, Guid>
    {
        public Guid Id { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid? ProductSlotId { get; set; }
        public string Title { get; set; }
    }
}