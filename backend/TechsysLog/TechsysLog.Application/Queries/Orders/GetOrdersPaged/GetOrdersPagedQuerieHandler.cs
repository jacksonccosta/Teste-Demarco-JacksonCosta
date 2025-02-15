using MediatR;
using TechsysLog.Application.Dtos.Pagination;
using TechsysLog.Domain.Entities;
using TechsysLog.Domain.Interfaces.Persistence.Orders;

namespace TechsysLog.Application.Queries.Orders.GetOrdersPaged;

public class GetOrdersPagedQuerieHandler(IOrderRepository orderRepository) : IRequestHandler<GetOrdersPagedQuerie, PagedResult<Order>>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<PagedResult<Order>> Handle(GetOrdersPagedQuerie querie, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetPagedAsync(querie.PageIndex, querie.PageSize);
        var ordersTotal = await _orderRepository.GetTotalCountAsync();

        if (orders is null)
        {
            return new PagedResult<Order>(0, new List<Order>());
        }

        var dto = new PagedResult<Order>(ordersTotal, orders);
        return dto;
    }
}
