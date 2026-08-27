using IntegrationModule.Sqlite;
using Microsoft.Extensions.DependencyInjection;

namespace Cucumber.Tests.Fixtures;

public static class ServiceProviderExtensionAppInit
{
    public static IServiceProvider DbInit(this IServiceProvider serviceProvider)
    {
        var initializer = serviceProvider.GetRequiredService<DatabaseInitializer>();
        initializer.Initialize();

        return serviceProvider;
    }
}