namespace IntravisionTestTask.Domain.Exceptinos
{
    public class ProductSlotAlreadyPlacedException : Exception
    {
        public ProductSlotAlreadyPlacedException() : base ("Product slot already placed in product machine!")
        {
        }
    }
}
