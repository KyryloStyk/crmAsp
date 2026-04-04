using System.ComponentModel.DataAnnotations;

public class CreateClientDto
{
    [Required]
    [MinLength(2)]
    public required string Name { get; set; }
}