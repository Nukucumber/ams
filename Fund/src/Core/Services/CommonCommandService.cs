using Fund.Core.Abstractions;
using Fund.Core.Entities;
using Fund.Core.Repositories;

namespace Fund.Core.Services;

internal sealed class CommonCommandService<TFundEntity> : CommandServiceBase<TFundEntity> where TFundEntity : IFundEntity
{
    private readonly IRepository<TFundEntity> _repository;

    public CommonCommandService(IUnitOfWork unitOfWork, IRepository<TFundEntity> repository) : base(unitOfWork)
    {
        _repository = repository;
    }

    protected override Task AddInternalAsync(
            TFundEntity entity,
            CancellationToken ct)
    {
        return _repository.AddAsync(entity, ct);
    }

    protected override Task UpdateInternalAsync(
        TFundEntity entity,
        CancellationToken ct)
    {
        return _repository.UpdateAsync(entity, ct);
    }

    protected override Task DeleteInternalAsync(
        string id,
        CancellationToken ct)
    {
        return _repository.DeleteAsync(id, ct);
    }
}


internal sealed class OwnerCommandService : CommandServiceBase<Owner>
{
    private readonly IRepository<Owner> _repository;

    public OwnerCommandService(IUnitOfWork unitOfWork, IRepository<Owner> repository) : base(unitOfWork)
    {
        _repository = repository;
    }

    protected override Task AddInternalAsync(Owner entity, CancellationToken ct)
    {
        Console.WriteLine("naaaanananannannannana");
        return Task.CompletedTask;
    }

    protected override Task DeleteInternalAsync(string id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    protected override Task UpdateInternalAsync(Owner entity, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}