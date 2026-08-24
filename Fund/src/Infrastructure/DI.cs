using Fund.Core;
using Fund.Core.Ports;
using Fund.Infrastructure.Implements;
using Fund.Infrastructure.SimpleSqlSourceGenerated;
using Microsoft.Extensions.DependencyInjection;

namespace Fund.Infrastructure;

public static class DI
{
    public static FundBuilder AddInfrastructure(this FundBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>()
                        .AddScoped<FundDbContext>()
                        .AddScoped<IEventDispatcher, EventDispatcher>()
                        .AddScoped<EventPublisherAbstract, EventPublisher>()
                        .AddSimpleSqlSourceGenerated();

        return builder;
    }
}