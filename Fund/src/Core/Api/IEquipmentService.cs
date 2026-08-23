namespace Fund.Core.Api;

public interface IEquipmentService
{
    Task Test(CancellationToken ct = default);
}
