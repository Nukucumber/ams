using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;

namespace IntegrationModule.Sqlite;

public class SqliteConnectionFactory(
    IOptions<SqliteOptions> option)
{
    public DbConnection Create()
    {       
        return new SqliteConnection(option.Value.ConnectionString);
    }
}