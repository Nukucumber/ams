using Fund.Core.Application.Abstractions;

namespace Fund.Core.Application.Ports;

public interface IQueryMediator
{
    Task<TResponse> Send<TQuery, TResponse>(
        TQuery query,
        CancellationToken ct = default)
        where TQuery : IQuery<TResponse>;


    IAsyncEnumerable<TResponse> CreateAsyncEnumerableStream<TQuery, TResponse>(
    TQuery query,
    CancellationToken ct = default)
    where TQuery : IQuery<TResponse>;

    Task<TResponse> CreateStream<TQuery, TResponse>(
    TQuery query,
    CancellationToken ct = default)
    where TQuery : IQuery<TResponse>;
}