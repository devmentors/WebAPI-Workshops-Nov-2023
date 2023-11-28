namespace Rossman;

public class IsNull
{
    public void Run()
    {
        var user = new User();

        var a = 1;
        
        if (user is null)
        {
            Console.WriteLine("User is null!");
        }
    }
}

public class User
{
    public int Age { get; set; }
    

    public static bool operator ==(User user1, User user2)
        => true;

    public static bool operator !=(User user1, User user2)
        => false;
}