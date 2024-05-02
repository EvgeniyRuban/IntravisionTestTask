using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Entities
{
    [Index(nameof(Title), IsUnique = true)]
    public class ProductType : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = null!; 
    }
}