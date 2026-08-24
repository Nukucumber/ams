using Fund.Core;
using Fund.Core.Abstractions;
using Fund.Infrastructure.SimpleSqlSourceGenerated;
using Microsoft.Extensions.DependencyInjection;

namespace Fund.Infrastructure;

public static class DI
{
    public static FundBuilder AddInfrastructure(this FundBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>()
                        .AddScoped<FundDbContext>()
                        .AddSimpleSqlSourceGenerated();

        return builder;
    }
}