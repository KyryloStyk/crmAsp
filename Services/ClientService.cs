public class ClientService
{
    private readonly AppDbContext _context;

    public ClientService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Client> GetAll()
    {
        return _context.Clients.ToList();
    }

    public Client? GetById(int id)
    {
        return _context.Clients.Find(id);
    }

    public void AddClient(Client client)
    {
        _context.Clients.Add(client);
        _context.SaveChanges();
    }

    public void DeleteClient(int id)
    {
        var client = _context.Clients.Find(id);
        if (client != null)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }
    }

    public Client Create(CreateClientDto dto)
{
    var client = new Client
    {
        Name = dto.Name
    };

    _context.Clients.Add(client);
    _context.SaveChanges();

    return client;
}

public void UpdateClient(int id, CreateClientDto dto)
{
    var client = _context.Clients.FirstOrDefault(c => c.Id == id);

    if (client == null)
        return;

    client.Name = dto.Name;

    _context.SaveChanges();
}

public bool Delete(int id)
{
    var client = _context.Clients.FirstOrDefault(c => c.Id == id);

    if (client == null)
        return false;

    _context.Clients.Remove(client);
    _context.SaveChanges();

    return true;
}
}