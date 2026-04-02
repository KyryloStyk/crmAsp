public class ClientService
{
    private readonly List<Client> _clients = new();

    public IEnumerable<Client> GetAll()
    {
        return _clients;
    }

    public Client? GetById(int id)
    {
        return _clients.FirstOrDefault(c => c.Id == id);
    }

    public Client Create(CreateClientDto dto)
    {
        var client = new Client
        {
            Id = GenerateId(),
            Name = dto.Name
        };

        _clients.Add(client);
        return client;
    }

    public bool Delete(int id)
    {
        var client = GetById(id);
        if (client == null) return false;

        _clients.Remove(client);
        return true;
    }

    private int GenerateId()
    {
        return _clients.Count == 0 ? 1 : _clients.Max(c => c.Id) + 1;
    }
}