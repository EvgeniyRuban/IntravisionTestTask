﻿using AutoMapper;
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
            var productType = await _context.ProductTypes
                .FirstOrDefaultAsync(pt => pt.Id ==  entity.ProductTypeId, cancellationToken);

            if (productType is null)
            {
                throw new EntityNotFoundException(typeof(ProductType));
            }

            if (entity.ProductSlotId is not null)
            {
                var productSlot = await _context.ProductSlots
                    .FirstOrDefaultAsync(ps => ps.Id == entity.ProductSlotId, cancellationToken);

                if (productSlot is null)
                {
                    throw new EntityNotFoundException(typeof (ProductSlot));
                }
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
            return await _context.Products
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }
        public async Task<ICollection<Product>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Products
                .Include (p => p.ProductType)
                .ToListAsync(cancellationToken);
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