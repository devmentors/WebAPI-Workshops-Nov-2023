using System.Data.Common;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Rossman;

public class AsynchronousProgramming
{
    public async void Run()
    {
        Console.WriteLine("Calculating sum...");

        var stopwatch = new Stopwatch();
        
        stopwatch.Start();

        var dbConnector = new DatabaseConnector();
        var apiConnector = new ExternalApiConnector();

        var dbTask = dbConnector.GetValueAsync();
        var apiTask = apiConnector.GetValueAsync();
        
        new Printer().Print();


        await Task.WhenAll(dbTask, apiTask);
        
        stopwatch.Stop();
        Console.WriteLine($"Result: {dbTask.Result + apiTask.Result} | elapsed: {stopwatch.ElapsedMilliseconds} ms");
    }
}

public class DatabaseConnector
{
    public int GetValue()
    {
        Console.WriteLine("Connecting to db...");
        Thread.Sleep(1_000);
        Console.WriteLine("Returning result from db...");

        return 10;
    }

    public async Task<int> GetValueAsync()
    {
        Console.WriteLine("Connecting to db...");
        await Task.Delay(10_000);
        Console.WriteLine("Returning result from db...");

        return 10;
    }
    
    // C# 4

    public async void Test()
    {
        // var await = 2;
    }
    
    // BEGIN / INVOKE
    // EAP
    // TAP - C# 5 
}

public class ExternalApiConnector
{
    public int GetValue()
    {
        Console.WriteLine("Connecting to external API...");
        Thread.Sleep(3_000);
        Console.WriteLine("Returning result from external API...");

        return 20;
    }
    
    public async Task<int> GetValueAsync()
    {
        Console.WriteLine("Connecting to external API...");
        await Task.Delay(30_000);
        Console.WriteLine("Returning result from external API...");

        return 20;
    }
}

public class Printer
{
    public void Print()
    {
        for (var i = 0; i < 10; ++i)
        {
            Console.WriteLine($"PRINT: {i}");
        }
    }
}

// IL

public class StateMachine : IAsyncStateMachine
{
    private int _state = 0;
    
    public void MoveNext()
    {
        if (_state is 0)
        {
            Console.WriteLine("Connecting to external API...");
            var awaiter = Task.Delay(30_000).GetAwaiter();
            // SCHEDULE
            _state = 1;
            return;
        }
        else if (_state is 1)
        {
            Console.WriteLine("Returning result from external API...");
        }
    }

    public void SetStateMachine(IAsyncStateMachine stateMachine)
    {
    }
}