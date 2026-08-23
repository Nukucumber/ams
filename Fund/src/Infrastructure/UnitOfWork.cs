using Fund.Core.Abstractions;

namespace Fund.Infrastructure;

internal class UnitOfWork(
    FundDbContext context
) : IUnitOfWork
{
    public async Task ExecuteAsync(Func<CancellationToken, Task> action, CancellationToken ct = default)
    {
        await context.BeginTransactionAsync(ct);

        try
        {
            await action(ct);

            await context.CommitAsync(ct);
        }
        catch
        {
            await context.RollbackAsync(ct);
            throw;
        }

    }
}