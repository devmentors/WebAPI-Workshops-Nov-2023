namespace MySpot.Core.Exceptions;

public abstract class MySpotException : Exception
{
    public MySpotException(string message) : base(message)
    {
    }
}

