using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Application.Api;

public interface ICommonEntityService<TFundEntity> where TFundEntity : FundEntityBase
{
    Task AddAsync(TFundEntity entity, CancellationToken ct = default);
    Task UpdateAsync(TFundEntity entity, CancellationToken ct = default);
    Task DeleteAsync(string id, CancellationToken ct = default);
    Task<TFundEntity?> GetByIdAsync(string id, CancellationToken ct = default);
    IAsyncEnumerable<TFundEntity> GetAllAsync(CancellationToken ct = default);
}
