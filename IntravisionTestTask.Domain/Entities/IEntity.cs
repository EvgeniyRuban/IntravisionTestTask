namespace IntravisionTestTask.Domain.Entities
{
    public interface IEntity<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
    }
}