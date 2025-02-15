using TechsysLog.Domain.Entities;

namespace TechsysLog.Domain.Interfaces.Persistence.Orders;

public interface IOrderRepository
{
    Task<List<Order>> GetPagedAsync(int pageIndex, int pageSize);
    Task<long> GetTotalCountAsync();
    Task<Order?> GetByNumberAsync(int number);
    Task<Order?> GetByIdAsync(Guid id);
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(Guid id);
    Task<List<Order>> GetAllAsync();
}
