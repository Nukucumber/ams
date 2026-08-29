using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Api;
using Fund.Core.Application.Commands;
using Fund.Core.Application.Facades;
using Fund.Core.Application.Queries;
using Fund.Core.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;


namespace Fund.Core.Application.Extensions;

internal static class FundBuilderExtensionServices
{
    public static FundBuilder AddCommonCrud<TEntity>(this FundBuilder builder)
    where TEntity : FundEntityBase
    {
        builder.Services.AddScoped<ICommandHandler<EntityAddCommand<TEntity>>, EntityAddCommandHandler<TEntity>>()
                        .AddScoped<ICommandHandler<EntityDeleteCommand<TEntity>>, EntityDeleteCommandHandler<TEntity>>()
                        .AddScoped<ICommandHandler<EntityUpdateCommand<TEntity>>, EntityUpdateCommandHandler<TEntity>>()
                        .AddScoped<IQueryHandler<EntityGetByIdQuery<TEntity>, TEntity?>, EntityGetByIdQueryHandler<TEntity>>()
                        .AddScoped<IAsyncEnumerableQueryHandler<EntityGetAllQuery<TEntity>, TEntity>, EntityGetAllQueryHandler<TEntity>>()
                        .AddScoped<ICommonEntityService<TEntity>, CommonEntityService<TEntity>>();

        return builder;
    }
}