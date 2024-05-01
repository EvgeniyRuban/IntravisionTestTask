using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductGetResponse : IGetResponse<Product, Guid>
    {
        public Guid Id { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid? ProductSlotId { get; set; }
        public string Title { get; set; }
        public ProductTypeGetResponse ProductType { get; set; }
    }
}