using Fund.Core.Api;
using Microsoft.AspNetCore.Mvc;

namespace Host.Api;

public static class RootApi
{
    public static IEndpointRouteBuilder AddRootApi(this IEndpointRouteBuilder builder)
    {
        builder.Get();

        return builder;
    }

    private static IEndpointRouteBuilder Get(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/", async ([FromServices] IEquipmentService equipmentService) =>
        {
            await equipmentService.Test();
        });

        return builder;
    }
}