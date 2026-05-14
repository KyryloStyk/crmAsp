
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Order>()
        .HasOne(order => order.Client)
        .WithMany(client => client.Orders)
        .HasForeignKey(order => order.ClientId)
        .OnDelete(DeleteBehavior.Cascade);

    base.OnModelCreating(modelBuilder);
}
}