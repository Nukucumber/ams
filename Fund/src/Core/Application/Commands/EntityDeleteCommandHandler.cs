using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Ports;
using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Application.Commands;

internal class EntityDeleteCommandHandler<TEntity> : ICommandHandler<EntityDeleteCommand<TEntity>>
where TEntity : FundEntityBase
{
    private readonly IRepository<TEntity> _repository;

    public EntityDeleteCommandHandler(IRepository<TEntity> repository)
    {
        _repository = repository;
    }


    public Task Handle(EntityDeleteCommand<TEntity> command, CancellationToken ct = default)
    {
        return _repository.DeleteAsync(command.EntityId, ct);
    }
}
