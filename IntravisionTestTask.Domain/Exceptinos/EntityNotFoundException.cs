namespace IntravisionTestTask.Domain.Exceptinos
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type entityType) : base($"Entity type of {entityType.Name} is not found!")
        {
        }
    }
}
