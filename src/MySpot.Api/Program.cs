using MySpot.Application;
using MySpot.Application.DTO;
using MySpot.Application.Services;
using MySpot.Core;
using MySpot.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCore()
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

app.MapGet("/", () => "MySpot API");

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