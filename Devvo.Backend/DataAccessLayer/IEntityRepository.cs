namespace Devvo.Backend.DataAccessLayer;

public interface IEntityRepository<TEntity>: IDisposable where TEntity: class
{
    Task<IEnumerable<TEntity>> FindAllAsync();
    Task<TEntity?> FindByIdAsync(Guid id);
    int Count(Func<TEntity, bool> predicate);
    Task AddAsync(TEntity entity);
    Task RemoveByIdAsync(Guid id);
    void Update(TEntity entity);
    Task SaveAsync();
}