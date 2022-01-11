using Application.Interfaces;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace StationsJob.Controllers;

[ApiController, Route("[controller]")]
public class Test : ControllerBase
{
    private readonly ProducerConfig _config = new ProducerConfig { BootstrapServers = "localhost:9092" };
    private readonly string _topic = "simpletalk_topic";
    private readonly IKafkaProducerService _kafkaProducerService;

    public Test(IKafkaProducerService kafkaProducerService)
    {
        _kafkaProducerService = kafkaProducerService;
    }

    [HttpGet]
    public async Task<IResult> Get()
    {
        // await _kafkaProducerService.ProduceAsync("__kk__", new TestMsgNotification {Message = "@@hey ho##"});
        return Results.Ok(" -- hey ho");
    }
}