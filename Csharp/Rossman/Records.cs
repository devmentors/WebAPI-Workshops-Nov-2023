using System.Text.Json;

namespace Rossman;

public class Records
{
    public void Run()
    {
        Console.WriteLine(Guid.NewGuid());

        var userDto = new UserDto(Guid.NewGuid(), "Joe Doe", "user@mail.com");
        var userDtoIl = new UserDtoIL
        {
            Id = Guid.NewGuid(), 
            FullName = "Joe Dow", 
            Email = "user@mail.com"
        };

        var (id, fullName, email) = userDto;
        var (id2, fullName2, email2) = userDtoIl;

        var userDto2 = userDto with {FullName = "Dariusz Pawlukiewicz"};

        var json = JsonSerializer.Serialize(userDto);
        Console.WriteLine(json);

        Console.WriteLine($"{userDto2.FullName} | mail: {userDto.Email}");

        Console.WriteLine();

        var myType = new MyType
        {
            Id = Guid.NewGuid()
        };
    }
}


public record UserDto(Guid Id, string FullName, string Email)
{
    public ushort Age { get; }
}

// public 
// private
// protected
// internal
// protected internal


public class UserDtoIL : IEquatable<UserDtoIL>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string FullName { get; init; } = "Joe Doe";
    public string Email { get; init; }

    public void Deconstruct(out Guid id, out string fullName, out string email)
    {
        id = Id;
        fullName = FullName;
        email = Email;
    }

    public bool Equals(UserDtoIL? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id) && FullName == other.FullName && Email == other.Email;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((UserDtoIL) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, FullName, Email);
    }
}