using Application;
using Application.Interfaces;
using Infrastructure.Gios;
using Infrastructure.Hangfire;
using Infrastructure.Kafka;
using Infrastructure.Redis;
using StationsJob.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddHangfireServices(builder.Configuration);
services.AddGiosServices();
services.AddKafkaServices(builder.Configuration);
services.AddRedisServices(builder.Configuration);
services.AddApplicationServices();
services.AddSwaggerGen();
services.AddScoped<IAppsettingsConfigServices, AppsettingsConfigServices>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseHangfireConfiguration();
app.MapControllers();
app.Run();