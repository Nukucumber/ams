namespace Fund.Core.Application.Abstractions;

public interface IAsyncEnumerableQueryHandler<TQuery, TResponse>
where TQuery : IQuery<TResponse>
{
    public IAsyncEnumerable<TResponse> Handle(TQuery query, CancellationToken ct = default);
}