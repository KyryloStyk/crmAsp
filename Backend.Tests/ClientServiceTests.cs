using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Full_Stackv2;
using api.DTOs.Client;
namespace Backend.Tests;

public class ClientServiceTests
{
    [Fact]
    public async Task Create_ShouldAddClient()
    {
        var context = TestDbFactory.Create();
        var logger = new Moq.Mock<ILogger<ClientService>>();

        var service = new ClientService(context, logger.Object);

        var dto = new CreateClientDto
        {
            Name = "John"
        };

        var result = await service.CreateAsync(dto);

        Assert.NotNull(result);
        Assert.Equal("John", result.Name);
        Assert.Single(context.Clients);
    }

    [Fact]
    public async Task Delete_ShouldReturnFalse_WhenNotFound()
    {
        var context = TestDbFactory.Create();
        var logger = new Moq.Mock<ILogger<ClientService>>();

        var service = new ClientService(context, logger.Object);

        var result = await service.DeleteAsync(999);

        Assert.False(result);
    }
}