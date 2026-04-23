using System.ComponentModel.DataAnnotations;

public class ClientDto
{
    [Required]
    [MinLength(2)]
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<OrderDto> Orders { get; set; } = new();
}