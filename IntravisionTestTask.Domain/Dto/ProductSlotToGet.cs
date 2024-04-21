namespace IntravisionTestTask.Domain.Dto
{
    public class ProductSlotToGet
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Capacity { get; set; }
    }
}