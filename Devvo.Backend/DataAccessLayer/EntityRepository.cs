namespace Devvo.Backend.DataAccessLayer;

using Devvo.Common.Model;
using Microsoft.EntityFrameworkCore;

public class EntityRepository<TEntity>: IEntityRepository<TEntity> where TEntity: class
{
    private ApplicationDbContext context;
    private bool disposed = false;
    
    public EntityRepository(ApplicationDbContext context)
    {
        this.context = context;
        this.context.Database.EnsureCreated();
    }

    public async Task<IEnumerable<TEntity>> FindAllAsync()
    {
        return await this.context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> FindByIdAsync(Guid id)
    {
        return await this.context.Set<TEntity>().FindAsync(id);
    }

    public int Count(Func<TEntity, bool> predicate)
    {
        return this.context.Set<TEntity>().Count(predicate);
    }

    public async Task AddAsync(TEntity entity)
    {
        await this.context.Set<TEntity>().AddAsync(entity);
    }

    public async Task RemoveByIdAsync(Guid id)
    {
        TEntity? entity = await this.context.Set<TEntity>().FindAsync(id);
        if (entity != null)
        {
            this.context.Set<TEntity>().Remove(entity);
        }
    }

    public void Update(TEntity entity)
    {
        this.context.Entry<TEntity>(entity).State = EntityState.Modified;
    }

    public async Task SaveAsync()
    {
        await this.context.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                this.context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }
}