using Microsoft.EntityFrameworkCore;
using api.DTOs.Auth;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<string> RegisterAsync(RegisterDto dto)
    {
        var userExists = await _context.Users
            .AnyAsync(u => u.Email == dto.Email);

        if (userExists)
            throw new Exception("User already exists");

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new User
        {
            Email = dto.Email,
            PasswordHash = passwordHash
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return "User registered";
    }

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (user == null)
            throw new Exception("Invalid email or password");

        var validPassword = BCrypt.Net.BCrypt.Verify(
            dto.Password,
            user.PasswordHash
        );

        if (!validPassword)
            throw new Exception("Invalid email or password");

        return "Login success";
    }
}