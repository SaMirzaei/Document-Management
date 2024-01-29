using Heinekamp.Application.Repositories;
using Heinekamp.Persistence.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Heinekamp.Domain;

namespace Heinekamp.Persistence.EntityFramework.Repositories;

public class Repository<T> : IRepository<T>
    where T : BaseEntity<long>
{
    private readonly HeinekampContext _dbContext;

    public Repository(HeinekampContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsyncIncluding(params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _dbContext.Set<T>();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return await query.ToListAsync();
    }

    public async Task<T> GetByIdAsync(long id, params Expression<Func<T, object>>[] includeProperties)
    {
        if (!includeProperties.Any())
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        IQueryable<T> query = _dbContext.Set<T>();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return await query.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<T> AddAsync(T entity)
    {
        var addedEntity = await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return addedEntity.Entity;
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public T FirstOrDefault(Expression<Func<T, bool>> predicate)
    {
        return _dbContext.Set<T>().FirstOrDefault(predicate);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();
    }
}