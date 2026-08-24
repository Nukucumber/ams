using System.Data.Common;

namespace Fund.Infrastructure.Abstractions;

public interface IDbConnectionFactory
{
    DbConnection Create();
}