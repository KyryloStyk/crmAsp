using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Full_Stackv2;
using api.DTOs.Auth;

namespace Backend.Tests;

public class AuthServiceTests
{
    [Fact]
    public async Task Register_ShouldCreateUser()
    {
        var context = TestDbFactory.Create();
        var service = new AuthService(context);

        var dto = new RegisterDto
        {
            Email = "test@mail.com",
            Password = "123456"
        };

        var result = await service.RegisterAsync(dto);

        Assert.Equal("User registered", result);
        Assert.Single(context.Users);
    }

    [Fact]
    public async Task Login_ShouldThrow_WhenUserNotExists()
    {
        var context = TestDbFactory.Create();
        var service = new AuthService(context);

        var dto = new LoginDto
        {
            Email = "notfound@mail.com",
            Password = "123"
        };

        await Assert.ThrowsAsync<Exception>(() => service.LoginAsync(dto));
    }
}