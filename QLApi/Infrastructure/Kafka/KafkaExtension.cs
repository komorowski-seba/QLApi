using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Kafka;

public static class KafkaExtension
{
    public static IServiceCollection AddKafkaServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(serviceProvider =>
        {
            var result = new ConsumerConfig
            {
                BootstrapServers = configuration.GetValue<string>("Kafka:BootstrapServer"),
                GroupId = configuration.GetValue<string>("Kafka:GroupId"),
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = true
            };
            return result;
        });
        services.AddHostedService<KafkaConsumer>();
        return services;
    }
}