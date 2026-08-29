using Fund.Core.Application.Abstractions;
using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Application.Queries;

internal record EntityGetAllQuery<TEntity>() : IQuery<TEntity>
where TEntity : FundEntityBase;