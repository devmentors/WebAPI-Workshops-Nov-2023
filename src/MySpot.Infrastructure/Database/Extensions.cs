using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Core.Repositories;

namespace MySpot.Infrastructure.Database;

internal static class Extensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        // var connectionString = configuration["database:connectionString"];
        var section = configuration.GetRequiredSection("database");
        var databaseOptions = new DatabaseOptions();
        section.Bind(databaseOptions);
        services.AddDbContext<MySpotDbContext>(x => x.UseNpgsql(databaseOptions.ConnectionString));
        // services.AddSingleton<IReservationRepository, InMemoryReservationRepository>();
        services.AddScoped<IReservationRepository, SqlReservationRepository>();
        return services;
    }
}