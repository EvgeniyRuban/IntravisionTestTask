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

        public async Task<ProductMachineToGet> Add(ProductMachineToCreate dto, CancellationToken cancellationToken)
        {
            var entityToCreate = _mapper.Map<ProductMachine>(dto);
            var newEntity = await _repository.Add(entityToCreate, cancellationToken);
            return _mapper.Map<ProductMachineToGet>(newEntity);
        }
        public async Task Delete(Guid key, CancellationToken cancellationToken)
        {
            await _repository.Delete(key, cancellationToken);
        }
        public async Task<ProductMachineToGet> Get(Guid key, CancellationToken cancellationToken)
        {
            var entity = await _repository.Get(key, cancellationToken);
            return _mapper.Map<ProductMachineToGet>(entity);
        }
        public async Task<ICollection<ProductMachineToGet>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);
            return _mapper.Map<ICollection<ProductMachineToGet>>(entities);
        }
        public async Task Update(ProductMachineToUpdate updateDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductMachine>(updateDto);
            await _repository.Update(entity, cancellationToken);
        }
    }
}