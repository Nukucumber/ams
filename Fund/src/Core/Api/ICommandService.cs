using Fund.Core.Abstractions;

namespace Fund.Core.Api;

public interface ICommandService<TFundEntity> where TFundEntity : FundEntityBase
{
    Task AddAsync(TFundEntity entity, CancellationToken ct = default);
    Task DeleteAsync(string id, CancellationToken ct = default);
    Task UpdateAsync(TFundEntity entity, CancellationToken ct = default);
}