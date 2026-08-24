using System.Data.Common;
using Fund.Infrastructure.Abstractions;

namespace Fund.Infrastructure;


internal sealed class FundDbContext(
    IDbConnectionFactory factory)
    : IAsyncDisposable, IDisposable
{
    private DbConnection? _connection;

    public DbConnection Connection => _connection
        ?? throw new InvalidOperationException(
            "Database connection is not open.");

    public DbTransaction? Transaction { get; private set; }

    public DbCommand CreateCommand()
    {
        var command = Connection.CreateCommand();

        command.Transaction = Transaction;

        return command;
    }


    private async Task<DbConnection> GetConnectionAsync(
    CancellationToken ct = default)
    {
        if (_connection is not null)
            return _connection;

        _connection = factory.Create();

        await _connection.OpenAsync(ct);

        return _connection;
    }

    public async Task BeginTransactionAsync(
        CancellationToken ct = default)
    {
        await GetConnectionAsync(ct);

        Transaction =
            await Connection.BeginTransactionAsync(ct);
    }

    public async Task CommitAsync(
        CancellationToken ct = default)
    {
        if (Transaction is null)
            throw new InvalidOperationException(
                "Transaction has not been started.");

        await Transaction.CommitAsync(ct);
        await Transaction.DisposeAsync();

        Transaction = null;
    }

    public async Task RollbackAsync(
        CancellationToken ct = default)
    {
        if (Transaction is null)
            return;

        await Transaction.RollbackAsync(ct);
        await Transaction.DisposeAsync();

        Transaction = null;
    }

    public async ValueTask DisposeAsync()
    {
        if (Transaction is not null)
            await Transaction.DisposeAsync();

        if (_connection is not null)
            await _connection.DisposeAsync();
    }

    public void Dispose()
    {
        if (Transaction is not null)
            Transaction.Dispose();

        if (_connection is not null)
            _connection.Dispose();
    }
}