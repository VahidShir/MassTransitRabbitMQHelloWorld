using MassTransit;
using MassTransitRabbitMQHelloWorld.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MassTransitRabbitMQHelloWorld.Consumers;

public class HelloWorldConsumer : IConsumer<HelloWorld>
{
    readonly ILogger<HelloWorldConsumer> _logger;

    public HelloWorldConsumer(ILogger<HelloWorldConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<HelloWorld> context)
    {
        _logger.LogInformation("Received Text: {Text}", context.Message.Value);
        return Task.CompletedTask;
    }
}