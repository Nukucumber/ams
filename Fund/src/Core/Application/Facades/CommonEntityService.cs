using Fund.Core.Application.Api;
using Fund.Core.Application.Commands;
using Fund.Core.Application.Ports;
using Fund.Core.Application.Queries;
using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Application.Facades;

internal sealed class CommonEntityService<TFundEntity> : ICommonEntityService<TFundEntity> where TFundEntity : FundEntityBase
{
    private readonly ICommandMediator _commandMediator;
    private readonly IQueryMediator _queryMediator;

    public CommonEntityService(ICommandMediator commandMediator, IQueryMediator queryMediator)
    {
        _commandMediator = commandMediator;
        _queryMediator = queryMediator;
    }


    public Task AddAsync(TFundEntity entity, CancellationToken ct)
    {
        var command = new EntityAddCommand<TFundEntity>(entity);
        return _commandMediator.Send(command, ct);
    }

    public Task UpdateAsync(TFundEntity entity, CancellationToken ct)
    {
        var command = new EntityUpdateCommand<TFundEntity>(entity);
        return _commandMediator.Send(command, ct);
    }

    public Task DeleteAsync(string id, CancellationToken ct)
    {
        var command = new EntityDeleteCommand<TFundEntity>(id);
        return _commandMediator.Send(command, ct);
    }

    public Task<TFundEntity?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        var query = new EntityGetByIdQuery<TFundEntity>(id);
        return _queryMediator.Send<EntityGetByIdQuery<TFundEntity>, TFundEntity?>(query, ct);
    }

    public IAsyncEnumerable<TFundEntity> GetAllAsync(CancellationToken ct = default)
    {
        var query = new EntityGetAllQuery<TFundEntity>();
        return _queryMediator.CreateAsyncEnumerableStream<EntityGetAllQuery<TFundEntity>, TFundEntity>(query, ct);
    }
}