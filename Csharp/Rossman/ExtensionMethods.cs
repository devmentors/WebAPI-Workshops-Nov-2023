namespace Rossman;

public class ExtensionMethods
{
    public void Run()
    {
        var numbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};

        var textNumbers = numbers.MySelect(x => x * x);

        var evenNumbers = numbers.GetEven(2);
        
        // IL

        var ilEvenNumbers = Extensions.GetEven(numbers, 2);

        Console.WriteLine(string.Join(',', evenNumbers));
    }
}


public static class Extensions
{
    public static IEnumerable<int> GetEven(this IEnumerable<int> collection, int number)
        => collection.Where(x => x % number is 0);
}


public static class MyCustomLinq
{
    public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source,
        Func<TSource, TResult> map)
    {
        foreach (var element in source)
        {
            yield return map(element);
        }
    }
}
