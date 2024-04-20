using IntravisionTestTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntravisionTestTask.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSlot> ProductSlots { get; set; }   
        public DbSet<ProductMachine> ProductMachines { get; set; }
    }
}
