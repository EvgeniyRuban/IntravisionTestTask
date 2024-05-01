namespace IntravisionTestTask.Domain.Exceptinos
{
    public class ProductSlotTypeDifferentException : Exception
    {
        public ProductSlotTypeDifferentException() : base("Product slot is filled with a different type of product! Free the slot first.")
        {
        }
    }
}
