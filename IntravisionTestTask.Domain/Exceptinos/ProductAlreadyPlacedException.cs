namespace IntravisionTestTask.Domain.Exceptinos
{
    public class ProductAlreadyPlacedException : Exception
    {
        public ProductAlreadyPlacedException() : base("Product already placed in product slot!")
        {
        }
    }
}
