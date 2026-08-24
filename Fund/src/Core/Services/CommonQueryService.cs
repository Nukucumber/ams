using System.Runtime.CompilerServices;
using Fund.Core.Abstractions;
using Fund.Core.Api;
using Fund.Core.Repositories;

namespace Fund.Core.Services;

internal sealed class CommonQueryService<TFundEntity> : IQueryService<TFundEntity> where TFundEntity : IFundEntity
{
    private readonly IRepository<TFundEntity> _repository;

    public CommonQueryService(IRepository<TFundEntity> repository)
    {
        _repository = repository;
    }


    public async IAsyncEnumerable<TFundEntity> GetAllAsync(
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await foreach (var entity in _repository.GetAllAsync(ct))
        {
            yield return entity;
        }

    }

    public async Task<TFundEntity?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        return await _repository.GetByIdAsync(id, ct);
    }
}