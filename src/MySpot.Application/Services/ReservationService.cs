using MySpot.Application.DTO;
using MySpot.Core.Entities;
using MySpot.Core.Exceptions;

namespace MySpot.Application.Services;

public sealed class ReservationService
{
    // Repository
    private static List<Reservation> _reservations = new();
    
    public async Task<IEnumerable<ReservationDto>> GetReservationsAsync()
    {
        await Task.CompletedTask;
        return _reservations.Select(x => new ReservationDto(x.ParkingSpotId,
            x.UserId, x.Date, x.LicencePlate));
    }
    
    public async Task ReserveParkingSpotAsync(ReservationDto dto)
    {
        await Task.CompletedTask;
        var (parkingSpotId, userId, date, licencePlate) = dto;

        var reservation = new Reservation(Guid.NewGuid(), date, 
            parkingSpotId, userId, licencePlate);
        
        _reservations.Add(reservation);
        

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