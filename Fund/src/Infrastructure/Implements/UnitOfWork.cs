using Fund.Infrastructure.Abstractions;

namespace Fund.Infrastructure.Implements;

internal class UnitOfWork : IUnitOfWork
{
    private readonly IFundDbContext _context;

    public UnitOfWork(IFundDbContext context)
    {
        _context = context;
    }


    public Task BeginTransactionAsync(CancellationToken ct = default) => _context.BeginTransactionAsync(ct);
    public Task CommitAsync(CancellationToken ct = default) => _context.CommitAsync(ct);
    public Task RollbackAsync(CancellationToken ct = default) => _context.RollbackAsync(ct);
}