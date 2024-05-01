using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;

namespace IntravisionTestTask.Domain.Services
{
    public interface ICrudService<TEntity, TKey, TGetRequest, TGetResponse, TCreateRequest, TCreateResponse, TUpdateRequest>
        where TKey : struct
        where TEntity : class, IEntity<TKey>
        where TGetRequest : class, IGetRequest<TEntity, TKey>
        where TGetResponse : class, IGetResponse<TEntity, TKey>
        where TCreateRequest : class, ICreateRequest<TEntity, TKey>
        where TCreateResponse : class, ICreateResponse<TEntity, TKey>
        where TUpdateRequest : class, IUpdateRequest<TEntity, TKey>
    {
        Task<TCreateResponse> Add(TCreateRequest request, CancellationToken cancellationToken);
        Task<TGetResponse> Get(TGetRequest request, CancellationToken cancellationToken);
        Task<ICollection<TGetResponse>> GetAll(CancellationToken cancellationToken);
        Task Update(TUpdateRequest request, CancellationToken cancellationToken);
        Task Delete(TKey key, CancellationToken cancellationToken);
    }
}