public class MyType
{
    public Guid Id { get; set; }
    private protected string Value { get; set; }
}


class MyType2 : MyType
{
    public MyType2()
    {
        Value = "";
    }
}

class MyType3
{
    public MyType3()
    {
    }
}