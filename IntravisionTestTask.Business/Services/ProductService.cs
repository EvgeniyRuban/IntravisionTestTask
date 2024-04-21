using AutoMapper;
using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;
using IntravisionTestTask.Domain.Repositories;
using IntravisionTestTask.Domain.Services;

namespace IntravisionTestTask.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductToGet> Add(ProductToCreate dto, CancellationToken cancellationToken)
        {
            var entityToCreate = _mapper.Map<Product>(dto);
            var newEntity = await _repository.Add(entityToCreate, cancellationToken);
            return _mapper.Map<ProductToGet>(newEntity);
        }
        public async Task Delete(Guid key, CancellationToken cancellationToken)
        {
            await _repository.Delete(key, cancellationToken);
        }
        public async Task<ProductToGet> Get(Guid key, CancellationToken cancellationToken)
        {
            var entity = await _repository.Get(key, cancellationToken);
            return _mapper.Map<ProductToGet>(entity);
        }
        public async Task<ICollection<ProductToGet>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);
            return _mapper.Map<ICollection<ProductToGet>>(entities);
        }
        public async Task Update(ProductToUpdate updateDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Product>(updateDto);
            await _repository.Update(entity, cancellationToken);
        }
    }
}