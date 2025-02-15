using TechsysLog.Domain.Entities;

namespace TechsysLog.Domain.Interfaces.Persistence.OrdersDelivery;

public interface IOrderDeliveryRepository
{
    Task<OrderDelivery> GetByOrderNumberAsync(int orderNumber);

    Task<OrderDelivery> GetByIdAsync(Guid id);

    Task AddAsync(OrderDelivery orderDelivery);

    Task UpdateAsync(OrderDelivery orderDelivery);

    Task DeleteAsync(Guid id);

    Task<List<OrderDelivery>> GetAllAsync();
}