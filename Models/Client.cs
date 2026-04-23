public class Client
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }

    public List<Order> Orders { get; set; } = new();
}

