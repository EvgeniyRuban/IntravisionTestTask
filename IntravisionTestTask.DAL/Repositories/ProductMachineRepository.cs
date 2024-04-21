using AutoMapper;
using IntravisionTestTask.DAL.EF;
using IntravisionTestTask.Domain.Entities;
using IntravisionTestTask.Domain.Exceptinos;
using IntravisionTestTask.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IntravisionTestTask.DAL.Repositories
{
    public class ProductMachineRepository : IProductMachineRepository
    {
        private readonly ApplicationContext _context;
        private IMapper _mapper;

        public ProductMachineRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductMachine> Add(ProductMachine entity, CancellationToken cancellationToken)
        {
            var newEntity = await _context.ProductMachines.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return newEntity.Entity;
        }
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductMachines.FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(ProductMachine));
            }

            _context.ProductMachines.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<ProductMachine?> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _context.ProductMachines
                .Include(pm => pm.ProductSlots)
                .FirstOrDefaultAsync(pm => pm.Id == id, cancellationToken);
        }
        public async Task<ICollection<ProductMachine>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.ProductMachines
                .Include(pm => pm.ProductSlots)
                .ToListAsync(cancellationToken);
        }
        public async Task Update(ProductMachine entityToUpdate, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductMachines.FirstOrDefaultAsync(e => e.Id == entityToUpdate.Id, cancellationToken);

            if(entity == null)
            {
                throw new EntityNotFoundException(typeof(ProductMachine));
            }

            _mapper.Map(entityToUpdate, entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}