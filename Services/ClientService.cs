using Microsoft.EntityFrameworkCore;


public class ClientService : IClientService
{
    private readonly AppDbContext _context;

    public ClientService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client?> GetByIdAsync(int id)
    {
        return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
    }

   public async Task<Client> CreateAsync(CreateClientDto dto)
{
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

    if (client == null)
        return false;

    client.Name = dto.Name;

    await _context.SaveChangesAsync();

    return true;
}

public async Task<bool> DeleteAsync(int id)
{
    var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

    if (client == null)
        return false;

    _context.Clients.Remove(client);
    await _context.SaveChangesAsync();

    return true;
}
}