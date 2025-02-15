using Microsoft.EntityFrameworkCore;
using TechsysLog.Domain.Entities;
using TechsysLog.Domain.Interfaces.Persistence.Orders;

namespace TechsysLog.Infrastructure.Persistence.Repositories.Orders;

public class OrderRepository : IOrderRepository
{
    private readonly SqlServerDbContext _context;

    public OrderRepository(SqlServerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<Order>> GetPagedAsync(int pageIndex, int pageSize)
    {
        var skip = (pageIndex - 1) * pageSize;

        return await _context.Orders
            .OrderBy(o => o.Number)
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<long> GetTotalCountAsync()
    {
        return await _context.Orders.CountAsync();
    }

    public async Task<Order?> GetByNumberAsync(int number)
    {
        return await _context.Orders
            .FirstOrDefaultAsync(o => o.Number == number);
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }
}
