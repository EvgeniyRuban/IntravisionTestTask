using AutoMapper;
using IntravisionTestTask.DAL.EF;
using IntravisionTestTask.Domain.Entities;
using IntravisionTestTask.Domain.Exceptinos;
using IntravisionTestTask.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IntravisionTestTask.DAL.Repositories
{
    public class ProductSlotRepository : IProductSlotRepository
    {
        private readonly ApplicationContext _context;
        private IMapper _mapper;

        public ProductSlotRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductSlot> Add(ProductSlot entity, CancellationToken cancellationToken)
        {
            var newEntity = await _context.ProductSlots.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return newEntity.Entity;
        }
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductSlots.FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(ProductSlot));
            }

            _context.ProductSlots.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<ProductSlot?> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _context.ProductSlots.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
        public async Task<ICollection<ProductSlot>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.ProductSlots.ToListAsync(cancellationToken);
        }
        public async Task Update(ProductSlot entityToUpdate, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductSlots.FirstOrDefaultAsync(e => e.Id == entityToUpdate.Id, cancellationToken);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(ProductSlot));
            }

            _mapper.Map(entityToUpdate, entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}