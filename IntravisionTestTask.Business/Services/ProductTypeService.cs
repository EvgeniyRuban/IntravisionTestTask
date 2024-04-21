using AutoMapper;
using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;
using IntravisionTestTask.Domain.Repositories;
using IntravisionTestTask.Domain.Services;

namespace IntravisionTestTask.Business.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _repository;
        private IMapper _mapper;

        public ProductTypeService(IProductTypeRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ProductTypeToGet> Add(ProductTypeToCreate dto, CancellationToken cancellationToken)
        {
            var entityToCreate = _mapper.Map<ProductType>(dto);
            var newEntity = await _repository.Add(entityToCreate, cancellationToken);
            return _mapper.Map<ProductTypeToGet>(newEntity);
        }
        public async Task Delete(Guid key, CancellationToken cancellationToken)
        {
            await _repository.Delete(key, cancellationToken);
        }
        public async Task<ProductTypeToGet> Get(Guid key, CancellationToken cancellationToken)
        {
            var entity = await _repository.Get(key, cancellationToken);
            return _mapper.Map<ProductTypeToGet>(entity);
        }
        public async Task<ICollection<ProductTypeToGet>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);
            return _mapper.Map<ICollection<ProductTypeToGet>>(entities);
        }
        public async Task Update(ProductTypeToUpdate updateDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductType>(updateDto);
            await _repository.Update(entity, cancellationToken);
        }
    }
}