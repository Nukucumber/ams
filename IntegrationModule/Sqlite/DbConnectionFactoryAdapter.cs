using System.Data.Common;
using Fund.Infrastructure;


namespace IntegrationModule.Sqlite;


public class DbConnectionFactoryAdapter : IDbConnectionFactory
{
    private readonly SqliteConnectionFactory _sqliteConnectionFactory;

    public DbConnectionFactoryAdapter(SqliteConnectionFactory sqliteConnectionFactory)
    {
        _sqliteConnectionFactory = sqliteConnectionFactory;
    }


    public DbConnection Create()
    {
        return _sqliteConnectionFactory.Create();
    }
}