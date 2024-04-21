using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Services
{
    public interface ICrudService<TEntity, TKey, TGetDto, TCreateDto, TUpdateDto>
        where TKey : struct
        where TEntity : class, IEntity<TKey>
        where TGetDto : class, IGetDto<TEntity, TKey>
        where TCreateDto : class, ICreateDto<TEntity, TKey>
        where TUpdateDto : class, IUpdateDto<TEntity, TKey>
    {
        Task<TGetDto> Add(TCreateDto dto, CancellationToken cancellationToken);
        Task<TGetDto> Get(TKey key, CancellationToken cancellationToken);
        Task<ICollection<TGetDto>> GetAll(CancellationToken cancellationToken);
        Task Update(TUpdateDto updateDto, CancellationToken cancellationToken);
        Task Delete(TKey key, CancellationToken cancellationToken);
    }
}