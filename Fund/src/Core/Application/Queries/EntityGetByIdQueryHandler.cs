using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Ports;
using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Application.Queries;

internal class EntityGetByIdQueryHandler<TEntity> : IQueryHandler<EntityGetByIdQuery<TEntity>, TEntity?>
where TEntity : FundEntityBase
{
    private readonly IRepository<TEntity> _repository;

    public EntityGetByIdQueryHandler(IRepository<TEntity> repository)
    {
        _repository = repository;
    }


    public async Task<TEntity?> Handle(EntityGetByIdQuery<TEntity> query, CancellationToken ct = default)
    {
        return await _repository.GetByIdAsync(query.EntityId, ct);
    }
}
