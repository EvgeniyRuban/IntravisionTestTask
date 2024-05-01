namespace IntravisionTestTask.Domain.Exceptinos
{
    public class ProductSlotLessCapacityException : Exception
    {
        public ProductSlotLessCapacityException() : base ("Product slot fillig cannot be less than their current filling! Free slots first.")
        {
        }
    }
}
