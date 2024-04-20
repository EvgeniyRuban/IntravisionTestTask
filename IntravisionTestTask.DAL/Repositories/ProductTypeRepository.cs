using AutoMapper;
using IntravisionTestTask.DAL.EF;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.DAL.Repositories
{
    public class ProductTypeRepository : CrudRepository<ProductType, Guid>
    {
        public ProductTypeRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}