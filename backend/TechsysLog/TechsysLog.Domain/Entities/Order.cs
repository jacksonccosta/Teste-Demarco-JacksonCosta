using TechsysLog.Domain.Enums;

namespace TechsysLog.Domain.Entities;

public class Order(int number, string description, decimal value, OrderAddress orderAddress)
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Number { get; set; } = number;
    public string Description { get; set; } = description;
    public decimal Value { get; set; } = value;
    public OrderStatusEnum Status { get; set; }
    public OrderAddress OrderAddress { get; set; } = orderAddress;

    public void SetOpenStatus()
    {
        Status = OrderStatusEnum.ABERTO;
    }

    public void SetAsDelivered()
    {
        Status = OrderStatusEnum.ENTREGUE;
    }
}
