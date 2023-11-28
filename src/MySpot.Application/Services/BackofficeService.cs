using MySpot.Application.DTO;
using MySpot.Core.Entities;

namespace MySpot.Application.Services;

public class BackofficeService
{
    public async Task ReserveParkingSpotAsync(ReservationDto dto)
    {
        var (parkingSpotId, userId, date, licencePlate) = dto;

        
        // DB save
        // send email
    }
}