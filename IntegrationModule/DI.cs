using Microsoft.Extensions.DependencyInjection;

namespace IntegrationModule;

public static class DI
{
    public static IntegrationBuilder GetIntegrationBuilder(this IServiceCollection services)
    {
        var builder = new IntegrationBuilder { Services = services };

        return builder;
    }
}