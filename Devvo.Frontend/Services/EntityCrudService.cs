namespace Devvo.Frontend.Services;

public class EntityCrudService<TEntityDto>: IEntityCrudService<TEntityDto>
{
    private readonly HttpClient client;
    private readonly string resourceName;
    
    public EntityCrudService(string baseAddress, string resourceName)
    {
        this.client = new HttpClient
        {
            BaseAddress = new Uri(baseAddress)
        };
        this.resourceName = resourceName;
    }

    public async Task<IEnumerable<TEntityDto>> FindAllAsync()
    {
        return await this.client.GetFromJsonAsync<IEnumerable<TEntityDto>>(this.resourceName) ?? [];
    }

    public async Task<TEntityDto?> FindByIdAsync(string id)
    {
        return await this.client.GetFromJsonAsync<TEntityDto?>($"{this.resourceName}/{id}");
    }

    public async Task<HttpResponseMessage> AddAsync(TEntityDto entity)
    {
        return await this.client.PostAsJsonAsync<TEntityDto>(this.resourceName, entity);
    }

    public async Task<HttpResponseMessage>  UpdateAsync(TEntityDto entity)
    {
        return await this.client.PutAsJsonAsync<TEntityDto>(this.resourceName, entity);
    }

    public async Task<HttpResponseMessage>  RemoveByIdAsync(string id)
    {
        return await this.client.DeleteAsync($"{this.resourceName}/{id}");
    }
}