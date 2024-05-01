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
            var productMachine = await _context.ProductMachines.FirstOrDefaultAsync(e => e.Id == entityToUpdate.Id, cancellationToken);

            if(productMachine == null)
            {
                throw new EntityNotFoundException(typeof(ProductMachine));
            }

            var productSlotsInMachineCount = await _context.ProductSlots.CountAsync(ps => ps.ProductMachineId == productMachine.Id);

            if (entityToUpdate.Capacity < productSlotsInMachineCount)
            {
                throw new EntityLessCapacityException(typeof(ProductMachine));
            }

            _mapper.Map(entityToUpdate, productMachine);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task AddProductSlotById(Guid id, Guid productSlotId, CancellationToken cancellationToken)
        {
            var machine = await _context.ProductMachines.FirstOrDefaultAsync(pm => pm.Id == id, cancellationToken);

            if (machine is null)
            {
                throw new EntityNotFoundException(typeof(ProductMachine));
            }

            var productSlot = await _context.ProductSlots
                .Include(ps => ps.ProductMachine)
                .FirstOrDefaultAsync(ps => ps.Id == productSlotId, cancellationToken);

            if (productSlot is null)
            {
                throw new EntityNotFoundException(typeof(ProductSlot));
            }

            if (productSlot.ProductMachine is not null)
            {
                throw new ProductSlotAlreadyPlacedException();
            }

            var productSlotCount = await _context.ProductSlots
                .Where(ps => ps.ProductMachineId == machine.Id)
                .CountAsync(cancellationToken);

            if (productSlotCount + 1 > machine.Capacity)
            {
                throw new ProductMachineHasNoSpaceException();
            }

            productSlot.ProductMachine = machine;
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task Clear(Guid id, CancellationToken cancellationToken)
        {
            var productMachine = await _context.ProductMachines
                .Include(pm => pm.ProductSlots)
                .FirstOrDefaultAsync(pm => pm.Id == id, cancellationToken);

            if(productMachine is null)
            {
                throw new EntityNotFoundException(typeof(ProductMachine));
            }

            productMachine.ProductSlots = null!;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}