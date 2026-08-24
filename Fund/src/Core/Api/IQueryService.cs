using Fund.Core.Abstractions;

namespace Fund.Core.Api;

public interface IQueryService<TFundEntity> where TFundEntity : IFundEntity
{
    public IAsyncEnumerable<TFundEntity> GetAllAsync(CancellationToken ct = default);

    public Task<TFundEntity?> GetByIdAsync(
        string id,
        CancellationToken ct = default);
}
