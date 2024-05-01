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

        public async Task<ProductCreateResponse> Add(ProductCreateRequest request, CancellationToken cancellationToken)
        {
            var entityToCreate = _mapper.Map<Product>(request);
            var newEntity = await _repository.Add(entityToCreate, cancellationToken);
            return _mapper.Map<ProductCreateResponse>(newEntity);
        }
        public async Task Delete(Guid key, CancellationToken cancellationToken)
        {
            await _repository.Delete(key, cancellationToken);
        }
        public async Task<ProductGetResponse> Get(ProductGetRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repository.Get(request.Id, cancellationToken);
            return _mapper.Map<ProductGetResponse>(entity);
        }
        public async Task<ICollection<ProductGetResponse>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);
            return _mapper.Map<ICollection<ProductGetResponse>>(entities);
        }
        public async Task Update(ProductUpdateRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Product>(request);
            await _repository.Update(entity, cancellationToken);
        }
    }
}