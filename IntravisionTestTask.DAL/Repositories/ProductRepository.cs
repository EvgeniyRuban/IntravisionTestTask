using AutoMapper;
using IntravisionTestTask.DAL.EF;
using IntravisionTestTask.Domain.Entities;
using IntravisionTestTask.Domain.Exceptinos;
using IntravisionTestTask.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IntravisionTestTask.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        private IMapper _mapper;

        public ProductRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Product> Add(Product entity, CancellationToken cancellationToken)
        {
            var existsSameTitle = await _context.Products.AnyAsync(p => p.Title == entity.Title);

            if (existsSameTitle)
            {
                throw new EntityAlreadyExistsException();
            }

            var newEntity = await _context.Products.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return newEntity.Entity;
        }
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(Product));
            }

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<Product?> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
        public async Task<ICollection<Product>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
        public async Task Update(Product entityToUpdate, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(e => e.Id == entityToUpdate.Id, cancellationToken);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(Product));
            }

            var titleExists = await _context.Products.AnyAsync(p => p.Title == entityToUpdate.Title, cancellationToken);

            if (titleExists)
            {
                throw new EntityAlreadyExistsException();
            }

            _mapper.Map(entityToUpdate, entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}