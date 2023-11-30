using Microsoft.Extensions.DependencyInjection;
using MySpot.Application.Services;

namespace MySpot.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IReservationService, ReservationService>();
        return services;
    }
}