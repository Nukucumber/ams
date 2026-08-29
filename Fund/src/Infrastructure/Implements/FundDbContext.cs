using System.Data.Common;
using Fund.Infrastructure.Abstractions;
using Fund.Infrastructure.Ports;

namespace Fund.Infrastructure.Implements;

internal sealed class FundDbContext : IAsyncDisposable, IDisposable, IFundDbContext
{
    private readonly IDbConnectionFactory _factory;
    private DbConnection? _connection;
    public DbConnection Connection => _connection ?? throw new InvalidOperationException("Connection has not been opened.");
    public DbTransaction? Transaction { get; private set; }

    public FundDbContext(IDbConnectionFactory factory)
    {
        _factory = factory;
    }


    public DbCommand CreateCommand()
    {
        var command = Connection.CreateCommand();
        command.Transaction = Transaction;

        return command;
    }

    public async Task OpenAsync(CancellationToken ct = default)
    {
        if (_connection is not null)
        {
            return;
        }
        _connection = _factory.Create();

        await _connection.OpenAsync(ct);
    }

    public async Task BeginTransactionAsync(CancellationToken ct = default)
    {
        if (Transaction is not null)
        {
            throw new InvalidOperationException("Transaction has already been started.");
        }
        await OpenAsync(ct);

        Transaction = await Connection.BeginTransactionAsync(ct);
    }

    public async Task CommitAsync(CancellationToken ct = default)
    {
        if (Transaction is null)
        {
            throw new InvalidOperationException("Transaction has not been started.");
        }

        try
        {
            await Transaction.CommitAsync(ct);
        }
        finally
        {
            await Transaction.DisposeAsync();
            Transaction = null;
        }
    }

    public async Task RollbackAsync(CancellationToken ct = default)
    {
        if (Transaction is null)
        {
            return;
        }

        try
        {
            await Transaction.RollbackAsync(ct);
        }
        finally
        {
            await Transaction.DisposeAsync();
            Transaction = null;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (Transaction is not null)
        {
            await Transaction.DisposeAsync();
        }
        if (_connection is not null)
        {
            await _connection.DisposeAsync();
        }
    }

    public void Dispose()
    {
        Transaction?.Dispose();
        _connection?.Dispose();
    }
}