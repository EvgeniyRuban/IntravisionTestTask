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

        public async Task<ProductTypeCreateResponse> Add(ProductTypeCreateRequest request, CancellationToken cancellationToken)
        {
            var entityToCreate = _mapper.Map<ProductType>(request);
            var newEntity = await _repository.Add(entityToCreate, cancellationToken);
            return _mapper.Map<ProductTypeCreateResponse>(newEntity);
        }
        public async Task Delete(Guid key, CancellationToken cancellationToken)
        {
            await _repository.Delete(key, cancellationToken);
        }
        public async Task<ProductTypeGetResponse> Get(ProductTypeGetRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repository.Get(request.Id, cancellationToken);
            return _mapper.Map<ProductTypeGetResponse>(entity);
        }
        public async Task<ICollection<ProductTypeGetResponse>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);
            return _mapper.Map<ICollection<ProductTypeGetResponse>>(entities);
        }
        public async Task Update(ProductTypeUpdateRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductType>(request);
            await _repository.Update(entity, cancellationToken);
        }
    }
}