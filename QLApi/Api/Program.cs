using Application;
using GraphQL.AspNet.Configuration.Mvc;
using Infrastructure.Kafka;
using Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddPersistenceServices(builder.Configuration);
services.AddApplicationServices(builder.Configuration);
services.AddSwaggerGen();
services.AddKafkaServices(builder.Configuration);
services.AddGraphQL();
services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UsePersistenceConfiguration();
app.UseGraphQL();
app.MapControllers();
app.Run();