using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;

namespace IntegrationModule.Sqlite;

public class SqliteConnectionFactory(
    IOptionsMonitor<SqliteOption> option)
{
    public DbConnection Create()
    {       
        return new SqliteConnection(option.CurrentValue.ConnectionString);
    }
}