using Fund.Core.Application.Api;
using Fund.Core.Application.Commands;
using Fund.Core.Application.Ports;
using Fund.Core.Domain.Entities;

namespace Fund.Core.Application.Facades;


internal sealed class AssetCommandService : IAssetCommandService
{
    private readonly ICommandMediator _commandMediator;

    public AssetCommandService(ICommandMediator commandMediator)
    {
        _commandMediator = commandMediator;
    }


    public Task AssetTransfer(Asset asset)
    {
        var command = new EntityAddCommand<Asset>(asset);

        return _commandMediator.Send(command);
    }
}