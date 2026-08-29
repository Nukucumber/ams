using Fund.Core.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Fund.Infrastructure.SubscriptionWatching;


public static class FundInfrastructureBuilderExtension
{
    public static FundInfrastructureBuilder AddSubscriptionWatcher(this FundInfrastructureBuilder builder)
    {
        builder.Services.AddSingleton<DateWatcher>();

        builder.Services.AddScoped<
            IEventHandler<NearestSubscriptionWatchRequestedEvent>,
            NearestSubscriptionWatchRequestedEventHandler>
            ();

        return builder;
    }
}

// public static class 