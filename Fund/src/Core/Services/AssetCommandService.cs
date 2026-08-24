using Fund.Core.Abstractions;
using Fund.Core.Entities;
using Fund.Core.Events;
using Fund.Core.Ports;
using Fund.Core.Repositories;

namespace Fund.Core.Services;

internal sealed class AssetCommandService : CommandServiceBase<Asset>
{
    private readonly IRepository<Asset> _repository;
    private readonly EventCollector _eventCollector;

    public AssetCommandService(IUnitOfWork unitOfWork, IRepository<Asset> repository, EventCollector eventCollector) : base(unitOfWork)
    {
        _repository = repository;
        _eventCollector = eventCollector;
    }

    protected override async Task AddInternalAsync(Asset entity, CancellationToken ct)
    {
        await _repository.AddAsync(entity, ct);
        _eventCollector.Collect(new AssetAddedEvent(entity.Id, entity.Name, entity.OwnerId));
    }

    protected override Task DeleteInternalAsync(string id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    protected override Task UpdateInternalAsync(Asset entity, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}