using Heinekamp.Application.Repositories;
using Heinekamp.Persistence.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Heinekamp.Persistence.EntityFramework.Repositories;

public class Repository<T> : IRepository<T> where T : class
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

    public async Task<T> GetByIdAsync(long id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
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
}