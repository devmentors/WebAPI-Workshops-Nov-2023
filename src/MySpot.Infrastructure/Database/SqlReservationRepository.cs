using Microsoft.EntityFrameworkCore;
using MySpot.Core.Entities;
using MySpot.Core.Repositories;

namespace MySpot.Infrastructure.Database;

internal sealed class SqlReservationRepository : IReservationRepository
{
    private readonly MySpotDbContext _dbContext;

    public SqlReservationRepository(MySpotDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Reservation?> GetAsync(Guid id)
        => _dbContext.Reservations.SingleOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Reservation>> GetAllAsync()
        => await _dbContext.Reservations.ToListAsync();

    public async Task AddAsync(Reservation reservation)
    {
        await _dbContext.Reservations.AddAsync(reservation);
        await _dbContext.SaveChangesAsync();
    }
}