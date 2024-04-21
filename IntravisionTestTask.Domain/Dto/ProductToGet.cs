namespace IntravisionTestTask.Domain.Dto
{
    public class ProductToGet
    {
        public Guid Id { get; set; }
        public Guid ProductTypeId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}