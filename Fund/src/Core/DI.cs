using Fund.Core.Api;
using Fund.Core.Entities;
using Fund.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Fund.Core;



public static class DI
{
    public static FundBuilder AddFundCore(this IServiceCollection services)
    {
        var builder = new FundBuilder { Services = services };

        builder.Services
                .AddScoped<ICommandService<Equipment>, CommonCommandService<Equipment>>()
                .AddScoped<ICommandService<Product>, CommonCommandService<Product>>()
                .AddScoped<ICommandService<Owner>, OwnerCommandService>();

        return builder;
    }
}