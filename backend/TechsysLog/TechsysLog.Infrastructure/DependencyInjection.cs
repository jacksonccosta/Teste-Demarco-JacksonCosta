using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechsysLog.Domain.Interfaces.Persistence.Orders;
using TechsysLog.Domain.Interfaces.Persistence.OrdersDelivery;
using TechsysLog.Domain.Interfaces.Persistence.Users;
using TechsysLog.Infrastructure.Persistence;
using TechsysLog.Infrastructure.Persistence.Repositories.Orders;
using TechsysLog.Infrastructure.Persistence.Repositories.OrdersDelivery;
using TechsysLog.Infrastructure.Persistence.Repositories.Users;

namespace TechsysLog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration, ServiceLifetime lifeTime = ServiceLifetime.Scoped)
    {
        services.AddDbContext<SqlServerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IOrderDeliveryRepository, OrderDeliveryRepository>();

        return services;
    }
}