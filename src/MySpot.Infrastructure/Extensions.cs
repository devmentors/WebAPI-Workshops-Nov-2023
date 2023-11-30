using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Infrastructure.Database;

namespace MySpot.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        var apiSection = configuration.GetRequiredSection("api");
        services.Configure<ApiOptions>(apiSection);
        services.AddDatabase();
        return services;
    }
}