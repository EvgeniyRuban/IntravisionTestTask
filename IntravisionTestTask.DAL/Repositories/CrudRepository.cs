using AutoMapper;
using IntravisionTestTask.DAL.EF;
using IntravisionTestTask.Domain.Entities;
using IntravisionTestTask.Domain.Exceptinos;
using IntravisionTestTask.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IntravisionTestTask.DAL.Repositories
{
    public abstract class CrudRepository<TEntity, TKey> : ICrudRepository<TEntity, TKey>
        where TKey : struct
        where TEntity : class, IEntity<TKey>
    {
        protected readonly ApplicationContext Context;
        protected readonly IMapper Mapper;


        public CrudRepository(ApplicationContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }


        public async Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken)
        {
            var newEntity = await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            return newEntity.Entity;
        }
        public async Task Delete(TKey id, CancellationToken cancellationToken)
        {
            var entityToDelete = await Context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);

            if (entityToDelete is null) 
            {
                throw new EntityNotFoundException(typeof(TEntity));
            }

            Context.Remove(entityToDelete);
            await Context.SaveChangesAsync(cancellationToken);
        }
        public async Task<TEntity> Get(TKey id, CancellationToken cancellationToken)
        {
            var entity = await Context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken); 

            if (entity is null)
            {
                throw new EntityNotFoundException(typeof(TEntity));
            }

            return entity;
        }
        public async Task<ICollection<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await Context.Set<TEntity>().ToListAsync(cancellationToken);
        }
        public async Task Update(TEntity entityToUpdate, CancellationToken cancellationToken)
        {
            var targetEntity = await Context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id.Equals(entityToUpdate.Id), cancellationToken);

            if (targetEntity is null)
            {
                throw new EntityNotFoundException(typeof(TEntity));
            }

            Mapper.Map(entityToUpdate, targetEntity);
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}