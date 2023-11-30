using Microsoft.Extensions.DependencyInjection;
using MySpot.Core.Repositories;

namespace MySpot.Infrastructure.Database;

internal static class Extensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddSingleton<IReservationRepository, InMemoryReservationRepository>();
        
        return services;
    }
}