namespace IntravisionTestTask.Domain.Exceptinos
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException() : base("Entity already exists!")
        {   
        }
    }
}
