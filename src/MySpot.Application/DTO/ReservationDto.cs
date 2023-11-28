namespace MySpot.Application.DTO;

public record ReservationDto(Guid ParkingSpotId, Guid UserId, 
    DateOnly Date, string LicencePlate);