using AutoMapper;
using IntravisionTestTask.DAL.EF;
using IntravisionTestTask.Domain.Entities;
using IntravisionTestTask.Domain.Exceptinos;
using IntravisionTestTask.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IntravisionTestTask.DAL.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationContext _context;
        private IMapper _mapper;

        public ProductTypeRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductType> Add(ProductType entity, CancellationToken cancellationToken)
        {
            var newEntity = await _context.ProductTypes.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return newEntity.Entity;
        }
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductTypes.FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(ProductType));
            }

            _context.ProductTypes.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<ProductType?> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _context.ProductTypes.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
        public async Task<ICollection<ProductType>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.ProductTypes.ToListAsync(cancellationToken);
        }
        public async Task Update(ProductType entityToUpdate, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductTypes.FirstOrDefaultAsync(e => e.Id == entityToUpdate.Id, cancellationToken);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(ProductType));
            }

            _mapper.Map(entityToUpdate, entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}