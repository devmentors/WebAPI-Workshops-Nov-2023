using MySpot.Application.DTO;
using MySpot.Core.Entities;
using MySpot.Core.Exceptions;

namespace MySpot.Application.Services;

public sealed class ReservationService
{
    public async Task ReserveParkingSpotAsync(ReservationDto dto)
    {
        var (parkingSpotId, userId, date, licencePlate) = dto;

        var reservation = new Reservation(Guid.NewGuid(), date, 
            parkingSpotId, userId, licencePlate);
        

        // DB save
        // send email
    }

    public async Task UpdateReservation(ReservationDto dto)
    {
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