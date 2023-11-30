using Microsoft.Extensions.Options;
using MySpot.Api;
using MySpot.Application;
using MySpot.Application.DTO;
using MySpot.Application.Services;
using MySpot.Core;
using MySpot.Infrastructure;
using MySpot.Infrastructure.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCore()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services
    .AddAuth()
    .AddControllers();

var app = builder.Build();

// app.UseAuth();

app.MapControllers();

app.MapGet("/", (IOptions<ApiOptions> options) => options.Value.Name);

var reservations = app.MapGroup("/reservations");

reservations.MapGet("/{id:guid}", async (Guid id, IReservationService reservationService) =>
{
    var reservation = await reservationService.GetReservationAsync(id);
    return reservation is null ? Results.NotFound() : Results.Ok(reservation);
}).WithName("Get reservation");

reservations.MapGet("/", async (IReservationService reservationService) =>
{
    return await reservationService.GetReservationsAsync();
});

reservations.MapPost("/", async (ReservationDto dto, IReservationService reservationService) =>
{
    var id = await reservationService.ReserveParkingSpotAsync(dto);
    return Results.CreatedAtRoute("Get reservation", new {id});
});

app.Run();