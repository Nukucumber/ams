using Fund.Core.Api;

namespace Fund.Core.Abstractions;

internal abstract class CommandServiceBase<TFundEntity>(
    IUnitOfWork unitOfWork) : ICommandService<TFundEntity> where TFundEntity : IFundEntity
{
    public Task AddAsync(
        TFundEntity entity,
        CancellationToken ct = default)
    {
        return unitOfWork.ExecuteAsync(
            ct => AddInternalAsync(entity, ct),
            ct);
    }

    public Task UpdateAsync(
        TFundEntity entity,
        CancellationToken ct = default)
    {
        return unitOfWork.ExecuteAsync(
            ct => UpdateInternalAsync(entity, ct),
            ct);
    }

    public Task DeleteAsync(
        string id,
        CancellationToken ct = default)
    {
        return unitOfWork.ExecuteAsync(
            ct => DeleteInternalAsync(id, ct),
            ct);
    }

    protected abstract Task AddInternalAsync(
        TFundEntity entity,
        CancellationToken ct);

    protected abstract Task UpdateInternalAsync(
        TFundEntity entity,
        CancellationToken ct);

    protected abstract Task DeleteInternalAsync(
        string id,
        CancellationToken ct);
}
