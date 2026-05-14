using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Full_Stackv2;
using api.DTOs.Order;
namespace Backend.Tests;

public class OrderServiceTests
{
    [Fact]
    public async Task Create_ShouldThrow_WhenClientNotExists()
    {
        var context = TestDbFactory.Create();
        var logger = new Moq.Mock<ILogger<OrderService>>();

        var service = new OrderService(context, logger.Object);

        var dto = new CreateOrderDto
        {
            ClientId = 1,
            Amount = 100
        };

        await Assert.ThrowsAsync<Exception>(() => service.CreateAsync(dto));
    }

    [Fact]
    public async Task Create_ShouldAddOrder_WhenClientExists()
    {
        var context = TestDbFactory.Create();
        var logger = new Moq.Mock<ILogger<OrderService>>();

        var client = new Client { Name = "Test" };
        context.Clients.Add(client);
        await context.SaveChangesAsync();

        var service = new OrderService(context, logger.Object);

        var dto = new CreateOrderDto
        {
            ClientId = client.Id,
            Amount = 200
        };

        var result = await service.CreateAsync(dto);

        Assert.NotNull(result);
        Assert.Equal(200, result.Amount);
        Assert.Single(context.Orders);
    }
}