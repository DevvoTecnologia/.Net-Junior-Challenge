namespace Devvo.Frontend.Services;

public interface IEntityCrudService<TEntityDto>
{
    Task<IEnumerable<TEntityDto>> FindAllAsync();
    Task<TEntityDto?> FindByIdAsync(string id);
    Task<HttpResponseMessage> AddAsync(TEntityDto entity);
    Task<HttpResponseMessage> UpdateAsync(TEntityDto entity);
    Task<HttpResponseMessage> RemoveByIdAsync(string id);
}