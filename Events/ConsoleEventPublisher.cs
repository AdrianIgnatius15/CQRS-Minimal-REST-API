public class ConsoleEventPublisher : IEventPublisher
{
    public Task PublishAsync<TEvent>(TEvent evt)
    {
        Console.WriteLine($"Event Published: {evt?.GetType().Name}");
        return Task.CompletedTask;
    }
}