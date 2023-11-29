using MySpot.Application.DTO;
using MySpot.Core.Entities;
using MySpot.Core.Exceptions;

namespace MySpot.Application.Services;

public sealed class ReservationService : IReservationService
{
    // Repository
    private readonly List<Reservation> _reservations = new();
    
    public async Task<ReservationDto?> GetReservationAsync(Guid id)
    {
        await Task.CompletedTask;
        var reservation = _reservations.SingleOrDefault(x => x.Id == id);
        return reservation is null ? null : Map(reservation);
    }

    public async Task<IEnumerable<ReservationDto>> GetReservationsAsync()
    {
        await Task.CompletedTask;
        return _reservations.Select(Map);
    }

    private static ReservationDto Map(Reservation reservation)
        => new(reservation.Id, reservation.ParkingSpotId,
            reservation.UserId, reservation.Date, reservation.LicencePlate);
    
    public async Task<Guid> ReserveParkingSpotAsync(ReservationDto dto)
    {
        await Task.CompletedTask;
        var (_, parkingSpotId, userId, date, licencePlate) = dto;

        var reservation = new Reservation(Guid.NewGuid(), date, 
            parkingSpotId, userId, licencePlate);
        
        _reservations.Add(reservation);

        return reservation.Id;


        // DB save
        // send email
    }

    public async Task UpdateReservation(ReservationDto dto)
    {
        await Task.CompletedTask;
        Reservation reservation = default; //DB GET

        try
        {
            reservation.ChangeLicencePate(dto.LicencePlate);
        }
        catch (MySpotException ex)
        {
            // HTTP 400
        }
        catch (Exception ex)
        {
            // HTTP 500
        }
    }
}