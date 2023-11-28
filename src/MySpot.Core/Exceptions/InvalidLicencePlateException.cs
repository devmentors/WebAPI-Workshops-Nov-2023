namespace MySpot.Core.Exceptions;

public sealed class InvalidLicencePlateException : MySpotException
{
    public InvalidLicencePlateException(string licencePlate) 
        : base($"Licence plate: {licencePlate} is invalid!")
    {
    }
}