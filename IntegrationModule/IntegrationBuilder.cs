using Microsoft.Extensions.DependencyInjection;

namespace IntegrationModule;

public class IntegrationBuilder
{
    public required IServiceCollection Services { get; init; }
}