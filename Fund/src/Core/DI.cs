using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Api;
using Fund.Core.Application.Commands;
using Fund.Core.Application.Events;
using Fund.Core.Application.Extensions;
using Fund.Core.Application.Facades;
using Fund.Core.Domain.Entities;
using Fund.Core.Domain.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Fund.Core;



public static class DI
{
    public static FundBuilder AddFundCore(this IServiceCollection services)
    {
        var builder = new FundBuilder { Services = services };

        builder.Services.AddScoped<EventCollector>();

        builder
                .AddCommonCrud<Asset>()
                .AddCommonCrud<ConfigurationUnit>()
                .AddCommonCrud<Equipment>()
                .AddCommonCrud<EquipmentType>()
                .AddCommonCrud<Owner>()
                .AddCommonCrud<OwnerType>()
                .AddCommonCrud<Product>()
                .AddCommonCrud<ProductSubscription>()
                .AddCommonCrud<Software>()
                .AddCommonCrud<SoftwareType>()
                .AddCommonCrud<SoftwareInstallation>();

        builder.Services.AddScoped<IAssetCommandService, AssetCommandService>();
        builder.Services.AddScoped<ICommandHandler<EntityAddCommand<Asset>>, AssetTransferCommandHandler>();

        return builder;
    }
}