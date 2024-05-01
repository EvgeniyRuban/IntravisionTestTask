using AutoMapper;
using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;
using IntravisionTestTask.Domain.Repositories;
using IntravisionTestTask.Domain.Services;

namespace IntravisionTestTask.Business.Services
{
    public class ProductSlotService : IProductSlotService
    {
        private readonly IProductSlotRepository _repository;
        private readonly IMapper _mapper;

        public ProductSlotService(IProductSlotRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductSlotCreateResponse> Add(ProductSlotCreateRequest request, CancellationToken cancellationToken)
        {
            var entityToCreate = _mapper.Map<ProductSlot>(request);
            var newEntity = await _repository.Add(entityToCreate, cancellationToken);
            return _mapper.Map<ProductSlotCreateResponse>(newEntity);
        }
        public async Task AddProductById(Guid id, Guid productId, CancellationToken cancellationToken)
        {
            await _repository.AddProductById(id, productId, cancellationToken);
        }
        public async Task Clear(Guid id, CancellationToken cancellation)
        {
            await _repository.Clear(id, cancellation);
        }
        public async Task Delete(Guid key, CancellationToken cancellationToken)
        {
            await _repository.Delete(key, cancellationToken);
        }
        public async Task<ProductSlotGetResponse> Get(ProductSlotGetRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repository.Get(request.Id, cancellationToken);
            return _mapper.Map<ProductSlotGetResponse>(entity);
        }
        public async Task<ICollection<ProductSlotGetResponse>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);
            return _mapper.Map<ICollection<ProductSlotGetResponse>>(entities);
        }
        public async Task Update(ProductSlotUpdateRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductSlot>(request);
            await _repository.Update(entity, cancellationToken);
        }
    }
}