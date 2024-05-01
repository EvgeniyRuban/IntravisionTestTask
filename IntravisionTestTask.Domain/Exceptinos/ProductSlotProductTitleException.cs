namespace IntravisionTestTask.Domain.Exceptinos
{
    public class ProductSlotProductTitleException : Exception
    {
        public ProductSlotProductTitleException() : base ("Product slot store products fo different title!")
        {
        }
    }
}
