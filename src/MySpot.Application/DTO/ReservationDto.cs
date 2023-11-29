namespace MySpot.Application.DTO;

public record ReservationDto(Guid Id, Guid ParkingSpotId, Guid UserId, 
    DateOnly Date, string LicencePlate);