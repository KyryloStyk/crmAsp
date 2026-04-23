public class Order
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int ClientId { get; set; }

    public Client? Client { get; set; }
}