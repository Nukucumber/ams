using Microsoft.Extensions.DependencyInjection;

namespace Fund.Core;

public sealed class FundBuilder
{
    public required IServiceCollection Services { get; init; }

    internal FundBuilder() { }
}