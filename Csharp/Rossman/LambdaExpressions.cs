using System.Linq.Expressions;

namespace Rossman;

public class LambdaExpressions
{
    public void Run()
    {
        var numbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8};
        
        Func<int, bool> isEven = number => number % 2 == 0;

        isEven.Invoke(1);
        
        
        var evenNumbers = numbers
            .Where(isEven)
            .Where(x => x > 5)
            .Min();

        Func<float, float> pow = number => number * number;
        Expression<Func<int, int>> powExpression = number => number * number;

        
        //EF Core
        // Daper
        
        
        var resultOfExpression = powExpression.Compile()(3);
    }

    public IEnumerable<int> GetResultFromDb(Expression<Func<int, bool>> predicate,
        Expression<Func<int, int>> orderBy)
    {
        var numbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8};
        var result = numbers.AsQueryable();
        
        if (predicate is not null)
        {
            result = result.Where(predicate);
        }

        return result;
    }
    
}

public class Calculator
{
    public int Pow(int number)
        => number * number;
}

