using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using api.DTOs.Order;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;
    private readonly ILogger<OrderService> _logger;

    public OrderService(AppDbContext context, ILogger<OrderService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.Client)
            .ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _context.Orders
            .Include(o => o.Client)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Order> CreateAsync(CreateOrderDto dto)
{
    _logger.LogInformation("Creating order for client {ClientId}", dto.ClientId);

    var clientExists = await _context.Clients.AnyAsync(c => c.Id == dto.ClientId);

    if (!clientExists)
        throw new Exception("Client not found");

    var order = new Order
    {
        Amount = dto.Amount,
        ClientId = dto.ClientId
    };

    _context.Orders.Add(order);
    await _context.SaveChangesAsync();

    return order;
}

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
            return false;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();

        return true;
    }
}