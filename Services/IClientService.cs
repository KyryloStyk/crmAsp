using api.DTOs.Client;
public interface IClientService
{
    Task<IEnumerable<Client>> GetAllAsync();
    Task<Client?> GetByIdAsync(int id);
    Task<Client> CreateAsync(CreateClientDto dto);
    Task<bool> UpdateAsync(int id, CreateClientDto dto);
    Task<bool> DeleteAsync(int id);
}
