using System.Text;
using Application.Interfaces;
using Application.Models.Commands;
using Application.Models.Dto;
using Application.Models.Redis;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace Infrastructure.Kafka;

public class KafkaProducerService : IKafkaProducerService, IDisposable
{
    private readonly Lazy<IProducer<string, string>> _producer;

    public KafkaProducerService(ConsumerConfig consumerConfig)
    {
        _producer = new Lazy<IProducer<string, string>>(() => new ProducerBuilder<string, string>(consumerConfig).Build());
    }

    public async Task ProvinceMessageAsync(IList<ProvinceDto> provinces)
    {
        var provincesTasks = provinces
            .Select(n => SendMsgAsync(
                nameof(KafkaProducerService), 
                new AddProvinceCommand { Province = n }))
            .ToList();
        await Task.WhenAll(provincesTasks);        
    }

    public async Task AirTestMessageAsync(AddStationStateCommand stationStateCommand)
    {
        await SendMsgAsync(nameof(KafkaProducerService), stationStateCommand);
    }

    private async Task SendMsgAsync(string key, INotification msg)
    {
        try
        {
            var serialisedMessage = JsonConvert.SerializeObject(msg);
            var messageType = msg.GetType().Name;
            var producedMessage = new Message<string, string>
            {
                Key = key,
                Value = serialisedMessage,
                Headers = new Headers {{"message-type", Encoding.UTF8.GetBytes(messageType)}}
            };
            await _producer.Value.ProduceAsync("simpletalk_topic", producedMessage);
        }
        catch (Exception e)
        {
            // ignored
        }
    }
    
    public void Dispose()
    {
        if (_producer.IsValueCreated)
            _producer.Value.Dispose();
    }
}