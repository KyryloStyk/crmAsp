using api.DTOs.Order;
public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task<Order> CreateAsync(CreateOrderDto dto);
    Task<bool> DeleteAsync(int id);
}