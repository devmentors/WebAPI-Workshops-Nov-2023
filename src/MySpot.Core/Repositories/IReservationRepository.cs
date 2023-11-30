using MySpot.Core.Entities;

namespace MySpot.Core.Repositories;

public interface IReservationRepository
{
    Task<Reservation?> GetAsync(Guid id);
    Task<IEnumerable<Reservation>> GetAllAsync();
    Task AddAsync(Reservation reservation);
}