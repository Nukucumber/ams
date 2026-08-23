using System.Data.Common;

namespace Fund.Infrastructure;

public interface IDbConnectionFactory
{
    DbConnection Create();
}