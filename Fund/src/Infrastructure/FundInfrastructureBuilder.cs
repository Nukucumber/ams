using Microsoft.Extensions.DependencyInjection;

namespace Fund.Infrastructure;

public sealed class FundInfrastructureBuilder
{
    public required IServiceCollection Services { get; init; }

    internal FundInfrastructureBuilder() { }
}