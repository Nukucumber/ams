using Microsoft.Extensions.DependencyInjection;

namespace Fund.Infrastructure.SimpleSqlSourceGenerated;


internal static class SimpleSqlSourceGeneratedDI
{
    public static IServiceCollection AddSimpleSqlSourceGenerated(this IServiceCollection services)
    {
        services.AddGeneratedRepositories();
        
        return services;
    }
}