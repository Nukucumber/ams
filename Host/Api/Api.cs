namespace Host.Api;


public static class Api
{
    public static IEndpointRouteBuilder MapApi(this IEndpointRouteBuilder builder)
    {
        builder.AddRootApi();

        return builder;
    }
}