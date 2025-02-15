using MediatR;
using Microsoft.AspNetCore.SignalR;
using TechsysLog.Application.Dtos.CreateOrder;
using TechsysLog.Application.Hubs.Orders;
using TechsysLog.Domain.Entities;
using TechsysLog.Domain.Interfaces.Persistence.Orders;

namespace TechsysLog.Application.Commands.Orders.CreateOrder;

public class CreateOrderCommandHandler(IOrderRepository orderRepository,
    IHubContext<OrdersHub> hubContext) : IRequestHandler<CreateOrderCommand, CreateOrderResponseDto>
{
    private readonly IHubContext<OrdersHub> _hubContext = hubContext;
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<CreateOrderResponseDto> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        await GetOrderByNumberAsync(command.Number, cancellationToken);

        var description = command.Description ?? throw new ArgumentNullException(nameof(command));
        var orderAddress = command.OrderAddress ?? throw new ArgumentNullException(nameof(command));

        var orderToCreate = new Order(command.Number, description, command.Value, orderAddress);
        orderToCreate.SetOpenStatus();

        await _orderRepository.AddAsync(orderToCreate);

        await _hubContext.Clients.All.SendAsync("ListarPedidos");

        var dto = CreateOrderResponseDto.New(orderToCreate);

        return dto;
    }

    private async Task GetOrderByNumberAsync(int orderNumber, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByNumberAsync(orderNumber);

        if (order is not null)
        {
            throw new Exception("Order Already Exists");
        }
    }
}
