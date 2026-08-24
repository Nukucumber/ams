using Fund.Core.Events;
using Fund.Infrastructure.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationModule.TgBot;

public static class IntegrationBuilderExtensionTgBot
{
    public static IntegrationBuilder AddTgBot(this IntegrationBuilder builder)
    {
        builder.Services.AddScoped<IEventHandler<AssetAddedEvent>, AssetAddedEventHandler>();

        return builder;
    }
}