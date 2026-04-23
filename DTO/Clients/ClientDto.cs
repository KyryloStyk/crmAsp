namespace api.DTOs.Client;
using api.DTOs.Order;

public class ClientDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<OrderDto> Orders { get; set; } = new();
}