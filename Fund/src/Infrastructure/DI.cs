using Fund.Core.Abstractions;
using Fund.Core.Api;
using Fund.Core.Services;
using Fund.Infrastructure.SimpleSqlSourceGenerated;
using Microsoft.Extensions.DependencyInjection;

namespace Fund.Infrastructure;

public static class DI
{
    public static IServiceCollection AddFund(this IServiceCollection services)
    {
        services.AddScoped<IEquipmentService, EquipmentService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<FundDbContext>();
        services.AddSimpleSqlSourceGenerated();

        return services;
    }
}