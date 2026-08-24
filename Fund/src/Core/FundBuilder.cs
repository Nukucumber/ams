using Microsoft.Extensions.DependencyInjection;

namespace Fund.Core;

public class FundBuilder
{
    public required IServiceCollection Services { get; init; }
}