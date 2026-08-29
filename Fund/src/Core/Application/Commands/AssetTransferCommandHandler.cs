using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Events;
using Fund.Core.Application.Exceptions;
using Fund.Core.Application.Ports;
using Fund.Core.Domain.Entities;

namespace Fund.Core.Application.Commands;

internal class AssetTransferCommandHandler : ICommandHandler<EntityAddCommand<Asset>>
{
    private readonly EventCollector _eventCollector;
    private readonly IRepository<Asset> _assetRepository;
    private readonly IRepository<Owner> _ownerRepository;

    public AssetTransferCommandHandler(
        EventCollector eventCollector,
        IRepository<Asset> assetRepository,
        IRepository<Owner> ownerRepository)
    {
        _eventCollector = eventCollector;
        _assetRepository = assetRepository;
        _ownerRepository = ownerRepository;
    }

    public async Task Handle(EntityAddCommand<Asset> command, CancellationToken ct = default)
    {

        await _assetRepository.AddAsync(command.Entity, ct);

        var @event = new AssetAddedEvent(
            command.Entity,
            // owner
            new Owner
            {
                Name = "name",
                TypeId = "tpd",
                Description = ""
            }
        );


        // var owner = await _ownerRepository.GetByIdAsync(command.Entity.OwnerId, ct)
        //     ?? throw new EntityNotFoundException(nameof(Owner), command.Entity.OwnerId);

        // _eventCollector.Collect(@event);
    }
}
