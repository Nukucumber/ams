using Microsoft.Extensions.DependencyInjection;

namespace Fund.Infrastructure.SimpleSqlSourceGenerated;


public static class SimpleSqlSourceGeneratedDI
{
    public static IServiceCollection AddSimpleSqlSourceGenerated(this IServiceCollection services)
    {
        services.AddGeneratedRepositories();
        
        return services;
    }
}