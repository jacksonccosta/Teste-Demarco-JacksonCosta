using Microsoft.EntityFrameworkCore;
using TechsysLog.Domain.Entities;
using TechsysLog.Domain.Interfaces.Persistence.OrdersDelivery;

namespace TechsysLog.Infrastructure.Persistence.Repositories.OrdersDelivery;

public class OrderDeliveryRepository : IOrderDeliveryRepository
{
    private readonly SqlServerDbContext _context;

    public OrderDeliveryRepository(SqlServerDbContext context)
    {
        _context = context;
    }

    public async Task<OrderDelivery> GetByOrderNumberAsync(int orderNumber)
    {
        return await _context.OrderDeliveries
            .FirstOrDefaultAsync(od => od.OrderNumber == orderNumber) ?? throw new InvalidOperationException("OrderDelivery not found");
    }

    public async Task<OrderDelivery?> GetByIdAsync(Guid id)
    {
        return await _context.OrderDeliveries.FindAsync(id);
    }

    public async Task AddAsync(OrderDelivery orderDelivery)
    {
        await _context.OrderDeliveries.AddAsync(orderDelivery);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrderDelivery orderDelivery)
    {
        _context.OrderDeliveries.Update(orderDelivery);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var orderDelivery = await _context.OrderDeliveries.FindAsync(id);
        if (orderDelivery != null)
        {
            _context.OrderDeliveries.Remove(orderDelivery);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<OrderDelivery>> GetAllAsync()
    {
        return await _context.OrderDeliveries.ToListAsync();
    }
}