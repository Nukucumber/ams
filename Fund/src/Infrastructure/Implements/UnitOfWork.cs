using Fund.Core.Ports;

namespace Fund.Infrastructure.Implements;

internal class UnitOfWork : IUnitOfWork
{
    private readonly FundDbContext _context;
    private readonly EventPublisherAbstract _eventPublisher;

    public UnitOfWork(FundDbContext context, EventPublisherAbstract eventPublisher)
    {
        _context = context;
        _eventPublisher = eventPublisher;
    }


    public async Task ExecuteAsync(Func<CancellationToken, Task> action, CancellationToken ct = default)
    {
        await _context.BeginTransactionAsync(ct);

        try
        {
            await action(ct);

            await _context.CommitAsync(ct);

            await _eventPublisher.Publish(ct);
        }
        catch
        {
            await _context.RollbackAsync(ct);
            throw;
        }
    }
}
