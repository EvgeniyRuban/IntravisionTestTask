using AutoMapper;
using IntravisionTestTask.DAL.EF;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.DAL.Repositories
{
    public class ProductMachineRepository : CrudRepository<ProductMachine, Guid>
    {
        public ProductMachineRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}