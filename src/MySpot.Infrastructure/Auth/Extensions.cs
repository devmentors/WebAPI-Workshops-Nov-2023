using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MySpot.Infrastructure.Auth;

public static class Extensions
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
        => services.AddScoped<AuthMiddleware>();

    public static IApplicationBuilder UseAuth(this IApplicationBuilder app)
        => app.UseMiddleware<AuthMiddleware>();
}