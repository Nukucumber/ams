using Fund.Core.Abstractions;
using Fund.Core.Api;
using Fund.Core.Entities;
using Fund.Core.Repositories;
using Fund.Core.Statuses;

namespace Fund.Core.Services;

public sealed class EquipmentService(
    IUnitOfWork unitOfWork,
    IRepository<Equipment> repository) : IEquipmentService
{
    public async Task Test(CancellationToken ct = default)
    {
        await unitOfWork.ExecuteAsync(async (ct) =>
        {
            var equipment = new Equipment
            {
                Id = "75575957f75840948c12ce647bcbcfbd",
                Name = "nameTest",
                TypeId = "6",
                SerialNumber = "218410924",
                InventoryNumber = "0002002",
                Status = EquipmentStatus.Active.ToString(),
                Description = "awfwaf\nwefwq\n",
                UserId = "124",
            };

            await repository.AddAsync(equipment, ct);
        }, ct);
    }
}



