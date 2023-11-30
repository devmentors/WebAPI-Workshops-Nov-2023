namespace MySpot.Core.Exceptions;

public sealed class InvalidReservationDateException : MySpotException
{
    public InvalidReservationDateException(DateOnly date)
        : base($"Reservation date is invalid: {date}")
    {
    }
}