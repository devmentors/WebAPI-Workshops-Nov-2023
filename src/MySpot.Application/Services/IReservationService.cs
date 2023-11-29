using MySpot.Application.DTO;

namespace MySpot.Application.Services;

public interface IReservationService
{
    Task<ReservationDto?> GetReservationAsync(Guid id);
    Task<IEnumerable<ReservationDto>> GetReservationsAsync();
    Task<Guid> ReserveParkingSpotAsync(ReservationDto dto);
    Task UpdateReservation(ReservationDto dto);
}