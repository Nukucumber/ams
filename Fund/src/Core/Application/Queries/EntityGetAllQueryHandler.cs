using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Ports;
using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Application.Queries;

internal class EntityGetAllQueryHandler<TEntity> : IAsyncEnumerableQueryHandler<EntityGetAllQuery<TEntity>, TEntity>
where TEntity : FundEntityBase
{
    private readonly IRepository<TEntity> _repository;

    public EntityGetAllQueryHandler(IRepository<TEntity> repository)
    {
        _repository = repository;
    }


    public IAsyncEnumerable<TEntity> Handle(EntityGetAllQuery<TEntity> query, CancellationToken ct)
    {
        return _repository.GetAllAsync(ct);
    }
}