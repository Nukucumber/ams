// using Fund.Core.Entities;
// using Fund.Core.Statuses;

// namespace Fund.Infrastructure.SubscriptionWatching;

// internal class NearestProductSubscriptionRepository : INearestProductSubscriptionRepository
// {
//     private readonly FundDbContext _context;

//     public NearestProductSubscriptionRepository(FundDbContext context)
//     {
//         _context = context;
//     }


//     public async Task<ProductSubscription?> GetNearest(CancellationToken ct = default)
//     {
//         var command = _context.CreateCommand();

//         command.CommandText = $"""
//         select 
//             Id,
//             ProductId,
//             StartedAt,
//             ExpiresAt,
//             Status,
//             ConfigurationUnitId
//         from {nameof(ProductSubscription)}
//         WHERE Status = '{SubscriptionStatus.Active}'
//         ORDER BY ExpiresAt ASC
//         LIMIT 1;
        
//         """;

//         await using var reader =
//             await command.ExecuteReaderAsync(ct);

//         if (!await reader.ReadAsync(ct))
//             return null;

//         return new ProductSubscription()
//         {
//             Id = reader.GetString(0),
//             ProductId = reader.GetString(1),
//             StartedAt = reader.GetFieldValue<DateTimeOffset>(2),
//             ExpiresAt = reader.GetFieldValue<DateTimeOffset>(3),
//             Status = reader.GetString(4),
//             ConfigurationUnitId = reader.GetString(5),
//         };
//     }
// }