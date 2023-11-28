using MySpot.Core.Exceptions;

namespace MySpot.Core.ValueObjects;

public record LicencePlate
{
    public string Value { get; }

    public LicencePlate(string value)
    {
        if (value.Length < 6)                                       
        {                                                                  
            throw new InvalidLicencePlateException(value);         
        }    
        
        Value = value;
    }

    public static implicit operator string(LicencePlate licencePlate)
        => licencePlate.Value;

    public static implicit operator LicencePlate(string value)
        => new(value);
}