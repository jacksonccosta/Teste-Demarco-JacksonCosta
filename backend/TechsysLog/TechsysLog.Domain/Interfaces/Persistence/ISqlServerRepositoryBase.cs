namespace TechsysLog.Domain.Interfaces.Persistence;

public interface ISqlServerRepositoryBase<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);
    Task<List<T>> GetPagedAsync(int pageIndex, int pageSize);
    Task<long> GetTotalCountAsync();
}