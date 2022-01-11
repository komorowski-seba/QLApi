using System.Reflection;
using System.Text;
using Application.Handlers.Commands;
using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Infrastructure.Kafka;

public class KafkaConsumer : BackgroundService
{
    private readonly ConsumerConfig _consumerConfig;
    private readonly IMediator _mediator;

    public KafkaConsumer(ConsumerConfig consumerConfig, IMediator mediator)
    {
        _consumerConfig = consumerConfig;
        _mediator = mediator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine($"**** [Start Kafka Consumer] ****");
        await Task.Run(() => StartConsumer(stoppingToken), stoppingToken);
    }

    private void StartConsumer(CancellationToken stoppingToken)
    {
        using var consumer = new ConsumerBuilder<string, string>(_consumerConfig).Build();
        consumer.Subscribe("simpletalk_topic");

        var applicationAssembly = Assembly.Load("QlApi.Application");
        var cts = new CancellationTokenSource();
        Console.CancelKeyPress += (_consumerConfig, evt) =>
        {
            evt.Cancel = true;
            cts.Cancel();
        };
        
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var msg = consumer.Consume(cts.Token);
                var msgTypeEncoded = msg.Message.Headers.GetLastBytes("message-type");
                var msgTypeHeader = Encoding.UTF8.GetString(msgTypeEncoded);
                var msgType = applicationAssembly.GetType($"Application.Handlers.Commands.{msgTypeHeader}");
                
                var msgNotification = JsonConvert.DeserializeObject(msg.Message.Value, msgType);
                if (msgNotification != null)
                    _mediator.Publish(msgNotification, stoppingToken).GetAwaiter().GetResult();
            }
            catch (OperationCanceledException) { }
        }
    }
}