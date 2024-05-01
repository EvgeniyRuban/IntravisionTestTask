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
            if (entity.ProductMachineId is not null && entity.ProductMachineId != Guid.Empty)
            {
                var machineToLink = await _context.ProductMachines.FirstOrDefaultAsync(pm => pm.Id == entity.ProductMachineId, cancellationToken);

                if (machineToLink is null)
                {
                    throw new EntityNotFoundException(typeof(ProductMachine));
                }
            }

            var newEntity = await _context.ProductSlots.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return newEntity.Entity;
        }
        public async Task AddProductById(Guid id,Guid productId, CancellationToken cancellationToken)
        {
            var productSlot = await _context.ProductSlots
                .Include(ps => ps.Products)
                .FirstOrDefaultAsync(ps => ps.Id == id, cancellationToken);

            if (productSlot is null)
            {
                throw new EntityNotFoundException(typeof(ProductSlot));
            }

            var product = await _context.Products
                .Include(p => p.ProductSlot)
                .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);

            if (product is null)
            {
                throw new EntityNotFoundException(typeof(Product));
            }

            if (product.ProductSlot is not null)
            {
                throw new ProductAlreadyPlacedException();
            }


            var hasProducts = productSlot.Products.Count > 0;

            if(hasProducts)
            {
                var currentProductInSlotTitle = productSlot.Products.First().Title;

                if (product.Title.ToLower() != currentProductInSlotTitle.ToLower())
                {
                    throw new ProductSlotProductTitleException();
                }
            }

            var productCount = productSlot.Products.Count;
            var hasFreeSpace = productCount < productSlot.Capacity;

            if(!hasFreeSpace)
            {
                throw new ProductSlotHasNoSpaceException();
            }

            product.ProductSlot = productSlot;

            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task Clear(Guid id, CancellationToken cancellationToken)
        {
            var productSlot = await _context.ProductSlots
                .Include(ps => ps.Products)
                .FirstOrDefaultAsync(ps => ps.Id == id, cancellationToken);

            if (productSlot is null)
            {
                throw new EntityNotFoundException(typeof(ProductSlot));
            }

            productSlot.Products = null;

            await _context.SaveChangesAsync(cancellationToken);
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
            return await _context.ProductSlots
                .Include(m => m.Products)
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
        public async Task<ICollection<ProductSlot>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.ProductSlots
                .Include(ps => ps.Products)
                .ToListAsync(cancellationToken);
        }
        public async Task Update(ProductSlot entityToUpdate, CancellationToken cancellationToken)
        {
            var productSlot = await _context.ProductSlots.FirstOrDefaultAsync(e => e.Id == entityToUpdate.Id, cancellationToken);

            if (productSlot == null)
            {
                throw new EntityNotFoundException(typeof(ProductSlot));
            }

            var products = await _context.Products
                .Where(p => p.ProductSlotId == productSlot.Id)
                .ToListAsync(cancellationToken);

            if (entityToUpdate.Capacity < products.Count)
            {
                throw new ProductSlotLessCapacityException();
            }

            _mapper.Map(entityToUpdate, productSlot);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}