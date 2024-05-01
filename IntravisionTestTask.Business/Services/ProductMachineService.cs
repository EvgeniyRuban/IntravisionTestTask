using AutoMapper;
using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;
using IntravisionTestTask.Domain.Repositories;
using IntravisionTestTask.Domain.Services;

namespace IntravisionTestTask.Business.Services
{
    public class ProductMachineService : IProductMachineService
    {
        private readonly IProductMachineRepository _repository;
        private readonly IMapper _mapper;

        public ProductMachineService(IProductMachineRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductMachineCreateResponse> Add(ProductMachineCreateRequest request, CancellationToken cancellationToken)
        {
            var entityToCreate = _mapper.Map<ProductMachine>(request);
            var newEntity = await _repository.Add(entityToCreate, cancellationToken);
            return _mapper.Map<ProductMachineCreateResponse>(newEntity);
        }
        public async Task Delete(Guid key, CancellationToken cancellationToken)
        {
            await _repository.Delete(key, cancellationToken);
        }
        public async Task<ProductMachineGetResponse> Get(ProductMachineGetRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repository.Get(request.Id, cancellationToken);
            return _mapper.Map<ProductMachineGetResponse>(entity);
        }
        public async Task<ICollection<ProductMachineGetResponse>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);
            return _mapper.Map<ICollection<ProductMachineGetResponse>>(entities);
        }
        public async Task Update(ProductMachineUpdateRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductMachine>(request);
            await _repository.Update(entity, cancellationToken);
        }
        public async Task AddProductSlotById(Guid id, Guid productSlotId, CancellationToken cancellationToken)
        {
            await _repository.AddProductSlotById(id, productSlotId, cancellationToken);
        }
        public async Task Clear(Guid id, CancellationToken cancellationToken)
        {
            await _repository.Clear(id, cancellationToken);
        }
    }
}