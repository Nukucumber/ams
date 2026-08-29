using Fund.Core;
using Fund.Core.Application.Events;
using Fund.Core.Application.Ports;
using Fund.Infrastructure.Abstractions;
using Fund.Infrastructure.Implements;
using Fund.Infrastructure.SimpleSqlSourceGenerated;
using Microsoft.Extensions.DependencyInjection;

namespace Fund.Infrastructure;

public static class DI
{
    public static FundInfrastructureBuilder AddInfrastructure(this FundBuilder builder)
    {
        var infraBuilder = new FundInfrastructureBuilder { Services = builder.Services };

        infraBuilder.Services
                        .AddScoped<IUnitOfWork, UnitOfWork>()
                        .AddScoped<IFundDbContext, FundDbContext>()

                        .AddScoped<Mediator>()
                        .AddScoped<ICommandMediator>(sp =>
                            new TransactionalMediator(
                                sp.GetRequiredService<Mediator>(),
                                sp.GetRequiredService<IUnitOfWork>(),
                                sp.GetRequiredService<IEventPublisher>(),
                                sp.GetRequiredService<EventCollector>()
                            ))
                        .AddScoped<IQueryMediator, Mediator>()

                        .AddScoped<IEventDispatcher, EventDispatcher>()
                        .AddSingleton<IEventPublisher, EventPublisher>()

                        .AddSimpleSqlSourceGenerated();

        return infraBuilder;
    }
}