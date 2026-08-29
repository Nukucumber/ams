namespace Fund.Core.Application.Abstractions;

public interface IQueryHandler<TQuery, TResponse>
where TQuery : IQuery<TResponse>
{
    public Task<TResponse> Handle(TQuery query, CancellationToken ct = default);
}