using Microsoft.Extensions.DependencyInjection;

namespace IntegrationModule;

public sealed class IntegrationBuilder
{
    public required IServiceCollection Services { get; init; }

    internal IntegrationBuilder() { }
}