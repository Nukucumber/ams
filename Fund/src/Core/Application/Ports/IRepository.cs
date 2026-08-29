using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Application.Ports;


public interface IRepository<T>
where T : FundEntityBase
{
    IAsyncEnumerable<T> GetAllAsync(
        CancellationToken ct = default);

    Task<T?> GetByIdAsync(
        string id,
        CancellationToken ct = default);

    Task AddAsync(
        T entity,
        CancellationToken ct = default);

    Task UpdateAsync(
        T entity,
        CancellationToken ct = default);

    Task DeleteAsync(
        string id,
        CancellationToken ct = default);
}