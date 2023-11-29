using MySpot.Application.DTO;
using MySpot.Application.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "MySpot API");

app.MapGet("/reservations", async () =>
{
    var reservationService = new ReservationService();
    return await reservationService.GetReservationsAsync();
});

app.MapPost("/reservations", async (ReservationDto dto) =>
{
    var reservationService = new ReservationService();
    await reservationService.ReserveParkingSpotAsync(dto);
});

app.Run();