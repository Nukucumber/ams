using Fund.Core.Api;
using Fund.Core.Ports;

namespace Fund.Core.Abstractions;

internal abstract class CommandServiceBase<TFundEntity>(IUnitOfWork unitOfWork) : ICommandService<TFundEntity>
where TFundEntity : IFundEntity
{
    public async Task AddAsync(
        TFundEntity entity,
        CancellationToken ct = default)
    {
        await unitOfWork.ExecuteAsync(
            ct => AddInternalAsync(entity, ct),
            ct);
    }

    public async Task UpdateAsync(
        TFundEntity entity,
        CancellationToken ct = default)
    {
        await unitOfWork.ExecuteAsync(
            ct => UpdateInternalAsync(entity, ct),
            ct);
    }

    public async Task DeleteAsync(
        string id,
        CancellationToken ct = default)
    {
        await unitOfWork.ExecuteAsync(
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