public class ClientService
{
    private readonly List<Client> _clients = new List<Client>();

    public IEnumerable<Client> GetAllClients()
    {
        return _clients;
    }

    public int GenerateId()
    {
        return _clients.Count > 0 ? _clients.Max(c => c.Id) + 1 : 1;
    }

    public Client? GetById(int id)
    {
        return _clients.FirstOrDefault(c => c.Id == id);
    }

    public Client Add(CreateClientDto dto)
{
    var client = new Client
    {
        Id = GenerateId(),
        Name = dto.Name,
        Email = $"{dto.Name.ToLower()}@example.com"
    };

    _clients.Add(client);

    return client;
}

    public bool DeleteClient(int id)
{
    var client = GetById(id);
    if (client == null)
        return false;

    _clients.Remove(client);
    return true;
}

}