using Fund.Core.Api;
using Fund.Core.Entities;
using Fund.Core.Services;
using Fund.Core.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Fund.Core;



public static class DI
{
    public static FundBuilder AddFundCore(this IServiceCollection services)
    {
        var builder = new FundBuilder { Services = services };

        builder.Services.AddScoped<EventCollector>();

        builder
            .AddCrudServices()
            .AddSpecialServices();
        
        return builder;
    }


    private static FundBuilder AddCrudServices(this FundBuilder builder)
    {
        builder.Services
                .AddScoped<ICommandService<Equipment>, CommonCommandService<Equipment>>()
                .AddScoped<ICommandService<EquipmentType>, CommonCommandService<EquipmentType>>()
                .AddScoped<ICommandService<Software>, CommonCommandService<Software>>()
                .AddScoped<ICommandService<SoftwareType>, CommonCommandService<SoftwareType>>()
                .AddScoped<ICommandService<Owner>, CommonCommandService<Owner>>()
                .AddScoped<ICommandService<OwnerType>, CommonCommandService<OwnerType>>()
                .AddScoped<ICommandService<Product>, CommonCommandService<Product>>();

        return builder;
    }

    public static FundBuilder AddSpecialServices(this FundBuilder builder)
    {
        builder.Services.AddScoped<ICommandService<Asset>, AssetCommandService>();

        return builder;
    }
}