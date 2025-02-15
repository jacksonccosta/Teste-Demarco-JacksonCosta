namespace TechsysLog.Domain.Entities;

public class OrderDelivery(string orderId, int orderNumber)
{
    public string? Id { get; set; }
    public string OrderId { get; set; } = orderId;
    public int OrderNumber { get; set; } = orderNumber;
    public DateTime Date { get; set; } = DateTime.Now;
}
