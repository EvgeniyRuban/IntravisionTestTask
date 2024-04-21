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

        public async Task<ProductSlotToGet> Add(ProductSlotToCreate dto, CancellationToken cancellationToken)
        {
            var entityToCreate = _mapper.Map<ProductSlot>(dto);
            var newEntity = await _repository.Add(entityToCreate, cancellationToken);
            return _mapper.Map<ProductSlotToGet>(newEntity);
        }
        public async Task Delete(Guid key, CancellationToken cancellationToken)
        {
            await _repository.Delete(key, cancellationToken);
        }
        public async Task<ProductSlotToGet> Get(Guid key, CancellationToken cancellationToken)
        {
            var entity = await _repository.Get(key, cancellationToken);
            return _mapper.Map<ProductSlotToGet>(entity);
        }
        public async Task<ICollection<ProductSlotToGet>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);
            return _mapper.Map<ICollection<ProductSlotToGet>>(entities);
        }
        public async Task Update(ProductSlotToUpdate updateDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductSlot>(updateDto);
            await _repository.Update(entity, cancellationToken);
        }
    }
}