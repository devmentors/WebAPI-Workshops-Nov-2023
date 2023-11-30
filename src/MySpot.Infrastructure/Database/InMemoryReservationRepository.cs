using MySpot.Core.Entities;
using MySpot.Core.Repositories;

namespace MySpot.Infrastructure.Database;

internal sealed class InMemoryReservationRepository : IReservationRepository
{
    private readonly List<Reservation> _reservations = new();
    
    public async Task<Reservation?> GetAsync(Guid id)
    {
        await Task.CompletedTask;
        return _reservations.SingleOrDefault(x => x.Id == id);
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync()
    {
        await Task.CompletedTask;
        return _reservations;
    }

    public async Task AddAsync(Reservation reservation)
    {
        await Task.CompletedTask;
        _reservations.Add(reservation);
    }
}