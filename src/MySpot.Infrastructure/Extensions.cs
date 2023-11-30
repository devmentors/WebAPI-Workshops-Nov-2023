using Microsoft.Extensions.DependencyInjection;
using MySpot.Infrastructure.Database;

namespace MySpot.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDatabase();
        return services;
    }
}