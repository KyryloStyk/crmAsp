public class Client
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }

    public int UserId { get; set; }

    public User? User { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}

