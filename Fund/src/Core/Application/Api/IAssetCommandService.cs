using Fund.Core.Domain.Entities;

namespace Fund.Core.Application.Api;

public interface IAssetCommandService
{
    Task AssetTransfer(Asset asset);
}
