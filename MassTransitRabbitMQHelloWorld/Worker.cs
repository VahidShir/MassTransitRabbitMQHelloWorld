using MassTransit;
using MassTransitRabbitMQHelloWorld.Contracts;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MassTransitRabbitMQHelloWorld;

public class Worker : BackgroundService
{
    readonly IBus _bus;

    public Worker(IBus bus)
    {
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _bus.Publish(new HelloWorld { Value = $"Hello world! The time is {DateTimeOffset.Now}" }, stoppingToken);

            await Task.Delay(7000, stoppingToken);
        }
    }
}
