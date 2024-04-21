namespace IntravisionTestTask.Domain.Dto
{
    public class ProductTypeToUpdate
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
    }
}