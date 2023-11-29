using Microsoft.Extensions.DependencyInjection;

namespace MySpot.Tests.Unit;

public class IocTests
{
    [Fact]
    public void test()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddSingleton<IService, Service1>()
            .AddSingleton<Foo>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<IService>();
        var message = service.GetMessage();
    }

    interface IService
    {
        string GetMessage();
    }

    class Service2 : IService
    {
        public string GetMessage() => "Hello 2";
    }

    class Service1 : IService
    {
        private readonly Foo _foo;
        public Guid Id { get; } = Guid.NewGuid();

        public Service1(Foo foo)
        {
            _foo = foo;
        }

        public string GetMessage() => "Hello 1";
    }

    class Foo
    {
    }
}