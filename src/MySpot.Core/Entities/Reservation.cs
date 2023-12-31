using MySpot.Core.Exceptions;
using MySpot.Core.ValueObjects;

namespace MySpot.Core.Entities;

public class Reservation
{
    public Guid Id { get; private set; }
    public DateOnly Date { get; private set; }
    public Guid ParkingSpotId { get;  private set; }
    public Guid UserId { get; private set; }
    public LicencePlate LicencePlate { get; private set; }

    private Reservation()
    {
    }

    public Reservation(Guid id, DateOnly date, Guid parkingSpotId,
        Guid userId, LicencePlate licencePlate)
    {
        Id = id;
        UserId = userId;
        ParkingSpotId = parkingSpotId;
    
        ChangeLicencePate(licencePlate);
        
        if (date <= DateOnly.FromDateTime(DateTime.UtcNow))
        {
            throw new InvalidReservationDateException(date);
        }

        Date = date;
    }

    public bool ChangeLicencePate(string licencePlate)
    {
        if (licencePlate.Length < 5)
        {
            return false;
        }

        LicencePlate = licencePlate;
        return true;
    }
    
    // vehicle type
    // status
    
    // 200 OK
    // 201 CREATED
    // 400 BAD REQUEST
    // 409 CONFLICT
    // 500 INTERNAL SERVER ERROR
    // 503 SERVICE UNAVAILABLE
}