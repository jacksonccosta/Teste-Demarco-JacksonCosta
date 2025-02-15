using Microsoft.EntityFrameworkCore;
using TechsysLog.Domain.Interfaces.Persistence;

namespace TechsysLog.Infrastructure.Persistence.Repositories;

public abstract class SqlServerRepositoryBase<T>(SqlServerDbContext context) : ISqlServerRepositoryBase<T> where T : class
{
    protected readonly SqlServerDbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(Guid id, T entity)
    {
        var existingEntity = await _dbSet.FindAsync(id);
        if (existingEntity != null)
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<T>> GetPagedAsync(int pageIndex, int pageSize)
    {
        var skip = (pageIndex - 1) * pageSize;
        return await _dbSet.Skip(skip)
                           .Take(pageSize)
                           .ToListAsync();
    }

    public async Task<long> GetTotalCountAsync()
    {
        return await _dbSet.CountAsync();
    }
}