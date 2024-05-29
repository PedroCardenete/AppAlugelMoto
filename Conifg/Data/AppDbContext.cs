using Microsoft.EntityFrameworkCore;
using TestApplication.Model;

namespace TestApplication.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Subscriber> Subscribers { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        
        // Configuração para User
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user", "application");
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Stock>()
            .HasOne(s => s.Vehicle)
            .WithMany()
            .HasForeignKey(s => s.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Location>()
            .HasOne(l => l.User)
            .WithMany()
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Location>()
            .HasOne(l => l.Subscriber)
            .WithMany()
            .HasForeignKey(l => l.SubscriberId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Location>()
            .HasOne(l => l.Vehicle)
            .WithMany()
            .HasForeignKey(l => l.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Location)
            .WithMany()
            .HasForeignKey(o => o.LocationId)
            .OnDelete(DeleteBehavior.Restrict);
        }
}