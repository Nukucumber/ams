using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Events;
using Fund.Infrastructure.SubscriptionWatching;
using IntegrationModule.TgBot.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationModule.TgBot;

public static class IntegrationBuilderExtensionTgBot
{
    public static IntegrationBuilder AddTgBot(this IntegrationBuilder builder, IConfigurationSection configurationSection)
    {
        builder.Services.Configure<TgBotOptions>(configurationSection);

        builder.Services
            .AddSingleton<TelegramBotClientFactory>()
            .AddSingleton<TelegramBotClientProvider>();

        builder.Services.AddScoped<IEventHandler<AssetAddedEvent>, AssetAddedEventHandler>();
        builder.Services.AddScoped<IEventHandler<ProductSubscriptionExpireEvent>, ProductSubscriptionExpireEventHandler>();

        return builder;
    }
}
