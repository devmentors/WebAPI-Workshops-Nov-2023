using MySpot.Application.DTO;
using MySpot.Application.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "MySpot API");

app.MapGet("/reservations/{id:guid}", async (Guid id) =>
{
    var reservationService = new ReservationService();
    var reservation = await reservationService.GetReservationAsync(id);
    return reservation is null ? Results.NotFound() : Results.Ok(reservation);
}).WithName("Get reservation");

app.MapGet("/reservations", async () =>
{
    var reservationService = new ReservationService();
    return await reservationService.GetReservationsAsync();
});

app.MapPost("/reservations", async (ReservationDto dto) =>
{
    var reservationService = new ReservationService();
    var id = await reservationService.ReserveParkingSpotAsync(dto);
    return Results.CreatedAtRoute("Get reservation", new {id});
});

app.Run();