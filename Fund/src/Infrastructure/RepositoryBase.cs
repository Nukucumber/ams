using System.Data.Common;

using System.Runtime.CompilerServices;

using Fund.Core.Abstractions;
using Fund.Core.Repositories;

namespace Fund.Infrastructure;

internal abstract class RepositoryBase<T>(
    FundDbContext context)
    : IRepository<T>
    where T : IFundEntity
{
    protected abstract string TableName { get; }

    protected abstract T Map(
        DbDataReader reader);

    protected abstract DbCommand CreateInsertCommand(
        DbConnection connection,
        T entity);

    protected abstract DbCommand CreateUpdateCommand(
        DbConnection connection,
        T entity);

    protected virtual string SelectColumns => "*";

    public async IAsyncEnumerable<T> GetAllAsync(
        [EnumeratorCancellation]
        CancellationToken ct = default)
    {
        await using var command =
            context.CreateCommand();

        command.CommandText = $"""
            SELECT {SelectColumns}
            FROM {TableName}
            """;

        await using var reader =
            await command.ExecuteReaderAsync(ct);

        while (await reader.ReadAsync(ct))
        {
            yield return Map(reader);
        }
    }

    public async Task<T?> GetByIdAsync(
        string id,
        CancellationToken ct = default)
    {
        await using var command =
            context.CreateCommand();

        command.CommandText = $"""
            SELECT {SelectColumns}
            FROM {TableName}
            WHERE Id = @id
            """;

        AddParameter(
            command,
            "@id",
            id);

        await using var reader =
            await command.ExecuteReaderAsync(ct);

        if (!await reader.ReadAsync(ct))
            return default;

        return Map(reader);
    }

    public async Task AddAsync(
        T entity,
        CancellationToken ct = default)
    {
        await using var command =
            CreateInsertCommand(
                context.Connection,
                entity);
                
        command.Transaction = context.Transaction;

        await command.ExecuteNonQueryAsync(ct);
    }

    public async Task UpdateAsync(
        T entity,
        CancellationToken ct = default)
    {
        await using var command =
            CreateUpdateCommand(
                context.Connection,
                entity);

        command.Transaction = context.Transaction;

        await command.ExecuteNonQueryAsync(ct);
    }

    public async Task DeleteAsync(
        string id,
        CancellationToken ct = default)
    {
        await using var command =
            context.CreateCommand();

        command.CommandText = $"""
            DELETE FROM {TableName}
            WHERE Id = @id
            """;

        AddParameter(
            command,
            "@id",
            id);

        await command.ExecuteNonQueryAsync(ct);
    }

    protected static void AddParameter(
        DbCommand command,
        string name,
        object? value)
    {
        var parameter =
            command.CreateParameter();

        parameter.ParameterName = name;
        parameter.Value =
            value ?? DBNull.Value;

        command.Parameters.Add(parameter);
    }
}