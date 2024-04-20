using AutoMapper;
using IntravisionTestTask.DAL.EF;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.DAL.Repositories
{
    public class ProductSlotRepository : CrudRepository<ProductSlot, Guid>
    {
        public ProductSlotRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}