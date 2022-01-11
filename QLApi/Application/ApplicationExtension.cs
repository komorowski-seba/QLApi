using System.Reflection;
using Application.Handlers.Commands;
using Application.Handlers.Query;
using Application.Mapping;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(AddProvinceCommandHandler).Assembly,
            typeof(AddStationStateCommandHandler).Assembly,
            typeof(GetAllAirHistoryQueryHandler).Assembly,
            typeof(GetAllProvincesHandler).Assembly,
            typeof(GetProvinceHandler).Assembly,
            typeof(GetStationTestHistoryQueryHandler).Assembly);
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        return services;
    }
}