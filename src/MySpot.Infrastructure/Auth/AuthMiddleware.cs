using Microsoft.AspNetCore.Http;

namespace MySpot.Infrastructure.Auth;

internal sealed class AuthMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.Request.Headers.TryGetValue("X-Token", out var header))
        {
            context.Response.StatusCode = 401;
            return;
        }

        if (header.ToString() != "secret")
        {
            context.Response.StatusCode = 401;
            return;
        }
    
        await next(context);
    }
}