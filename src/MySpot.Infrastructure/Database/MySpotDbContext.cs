using Microsoft.EntityFrameworkCore;
using MySpot.Core.Entities;

namespace MySpot.Infrastructure.Database;

public sealed class MySpotDbContext : DbContext
{
    public DbSet<Reservation> Reservations { get; set; }

    public MySpotDbContext(DbContextOptions<MySpotDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new ReservationConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}