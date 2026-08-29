using System.Data.Common;

namespace Fund.Infrastructure.Abstractions;

internal interface IFundDbContext
{
    DbConnection Connection { get; }
    DbTransaction? Transaction { get; }

    Task BeginTransactionAsync(CancellationToken ct = default);
    Task CommitAsync(CancellationToken ct = default);
    DbCommand CreateCommand();
    void Dispose();
    ValueTask DisposeAsync();
    Task OpenAsync(CancellationToken ct = default);
    Task RollbackAsync(CancellationToken ct = default);
}
