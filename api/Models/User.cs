public class User
{
    public int Id { get; set; }

    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public string Role { get; set; } = "User";

    public ICollection<Client> Clients { get; set; } = new List<Client>();
}