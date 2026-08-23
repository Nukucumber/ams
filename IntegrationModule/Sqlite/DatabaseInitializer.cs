using Fund.Infrastructure;
using Fund.Infrastructure.SimpleSqlSourceGenerated;


namespace IntegrationModule.Sqlite;

public class DatabaseInitializer
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public DatabaseInitializer(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public void Initialize()
    {
        DbDataInitializer.DataInit(_dbConnectionFactory.Create());
    }
}