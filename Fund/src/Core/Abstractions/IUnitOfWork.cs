namespace Fund.Core.Abstractions;

public interface IUnitOfWork
{
    Task ExecuteAsync(
        Func<CancellationToken, Task> action, CancellationToken ct = default);
}