using System.ComponentModel.DataAnnotations;

public class CreateClientDto
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; }
}