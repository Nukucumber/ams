using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Ports;
using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Application.Commands;

internal class EntityAddCommandHandler<TEntity> : ICommandHandler<EntityAddCommand<TEntity>>
where TEntity : FundEntityBase
{
    private readonly IRepository<TEntity> _repository;

    public EntityAddCommandHandler(IRepository<TEntity> repository)
    {
        _repository = repository;
    }


    public Task Handle(EntityAddCommand<TEntity> command, CancellationToken ct = default)
    {
        return _repository.AddAsync(command.Entity, ct);
    }
}
