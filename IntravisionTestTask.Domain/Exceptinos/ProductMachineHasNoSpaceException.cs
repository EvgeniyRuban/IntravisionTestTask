namespace IntravisionTestTask.Domain.Exceptinos
{
    public class ProductMachineHasNoSpaceException : Exception
    {
        public ProductMachineHasNoSpaceException() : base ("Product machine has no space to add product slot!")
        {
        }
    }
}
