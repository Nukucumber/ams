using System.Data.Common;

namespace Fund.Infrastructure.Ports;

public interface IDbConnectionFactory
{
    DbConnection Create();
}