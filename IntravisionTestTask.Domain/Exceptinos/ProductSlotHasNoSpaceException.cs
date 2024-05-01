namespace IntravisionTestTask.Domain.Exceptinos
{
    public class ProductSlotHasNoSpaceException : Exception
    {
        public ProductSlotHasNoSpaceException() : base("Product slot has no space to add product!")
        {
        }
    }
}
