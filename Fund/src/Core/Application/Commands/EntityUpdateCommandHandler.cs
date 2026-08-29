using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Ports;
using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Application.Commands;

internal class EntityUpdateCommandHandler<TEntity> : ICommandHandler<EntityUpdateCommand<TEntity>>
where TEntity : FundEntityBase
{
    private readonly IRepository<TEntity> _repository;

    public EntityUpdateCommandHandler(IRepository<TEntity> repository)
    {
        _repository = repository;
    }


    public Task Handle(EntityUpdateCommand<TEntity> command, CancellationToken ct = default)
    {
        return _repository.UpdateAsync(command.Entity, ct);
    }
}