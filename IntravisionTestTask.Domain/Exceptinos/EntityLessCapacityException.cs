namespace IntravisionTestTask.Domain.Exceptinos
{
    public class EntityLessCapacityException : Exception
    {
        public EntityLessCapacityException(Type entityType) 
            : base ($"{entityType.Name} fillig cannot be less than their current filling! Free {entityType.Name} first.")
        {
        }
    }
}
