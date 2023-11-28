namespace Rossman;

public class ParkingSpotProblem
{
    
}

public class ReservationService
{
    private readonly InMemoryDatabase _database = new();
    
    public void ReserveParkingSpot(ReservationDto dto)
    {
        var (date, userId, parkingSpotId, licencePlate) = dto;

        //DOMAIN LOGIC
        var numberOfReservations = _database.Reservations
            .Count(x => x.UserId == userId);
        
        var reservation = new Reservation
        {
            Id = Guid.NewGuid(),
            Date = date,
            UserId = userId,
            ParkingSpotId = parkingSpotId,
            LicencePlate = licencePlate // 0XDEADBEEF
        };

        _database.Reservations.Add(reservation);
    }
}

public record ReservationDto(DateOnly date, Guid userId, Guid parkingSpotId, string licencePlate);

public class InMemoryDatabase
{
    public HashSet<Reservation> Reservations = new();
}

public class Reservation
{
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public Guid UserId { get; set; }
    public Guid ParkingSpotId { get; set; }
    public string LicencePlate { get; set; }
}