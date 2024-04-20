using AutoMapper;
using IntravisionTestTask.DAL.EF;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.DAL.Repositories
{
    public class ProductRepository : CrudRepository<Product, Guid>
    {
        public ProductRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}