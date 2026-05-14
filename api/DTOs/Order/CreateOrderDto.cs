namespace api.DTOs.Order;

public class CreateOrderDto
{
    public decimal Amount { get; set; }
    public int ClientId { get; set; }
}