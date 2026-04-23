using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


public class ClientService : IClientService
{
    private readonly ILogger<ClientService> _logger;
    private readonly AppDbContext _context;

    public ClientService(AppDbContext context, ILogger<ClientService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _context.Clients
        .Include(c => c.Orders)
        .ToListAsync();
    }

    public async Task<Client?> GetByIdAsync(int id)
    {
        _logger.LogInformation("Getting client by id: {Id}", id);
        return await _context.Clients
    .Include(c => c.Orders)
    .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Client> CreateAsync(CreateClientDto dto)
    {
        _logger.LogInformation("Creating client: {Name}", dto.Name);
        var client = new Client
        {
            Name = dto.Name
        };

        _context.Clients.Add(client);
        await _context.SaveChangesAsync();

        return client;
    }

    public async Task<bool> UpdateAsync(int id, CreateClientDto dto)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

        _logger.LogInformation("Updating client id: {Id}", id);

        if (client == null)
            return false;

        client.Name = dto.Name;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _logger.LogInformation("Deleting client id: {Id}", id);
        var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

        if (client == null)
            return false;

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return true;
    }
}