using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;

namespace socialHelp.Helpers
{
    public class DataContext{
    private DbSettings _dbSettings;

    public DataContext(IOptions<DbSettings> dbSettings)
    {
        _dbSettings = dbSettings.Value;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = $"Host={_dbSettings.Server}; Port={_dbSettings.Port}; Database={_dbSettings.Database}; Username={_dbSettings.UserId}; Password={_dbSettings.Password};";
        return new NpgsqlConnection(connectionString);
    }

    public async Task Init()
    {
        await _initDatabase();
        await _initTables();
    }

    private async Task _initDatabase()
    {
        var connectionString = $"Host={_dbSettings.Server};  Port={_dbSettings.Port}; Database=postgres; Username={_dbSettings.UserId}; Password={_dbSettings.Password};";
        using var connection = new NpgsqlConnection(connectionString);
        var sqlDbCount = $"SELECT COUNT(*) FROM pg_database WHERE datname = '{_dbSettings.Database}';";
        var dbCount = await connection.ExecuteScalarAsync<int>(sqlDbCount);
        if (dbCount == 0)
        {
            var sql = $"CREATE DATABASE \"{_dbSettings.Database}\"";
            await connection.ExecuteAsync(sql);
        }
    }

    private async Task _initTables()
    {
        using var connection = this.CreateConnection();
        await _initSocialHelps();
        await _initBeneficiaries();

        async Task _initSocialHelps()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS socialhelps (
                Id VARCHAR(50) PRIMARY KEY DEFAULT gen_random_uuid(),
                Name VARCHAR(255) NOT NULL,
                Description VARCHAR(255),
                locationType VARCHAR(10) NOT NULL,
                locationId VARCHAR(100) NOT NULL,
                DateActivation TIMESTAMP,
                DateExpiration TIMESTAMP,
                CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                UpdatedAt TIMESTAMP,
                DeletedAt TIMESTAMP);
            """;
            await connection.ExecuteAsync(sql);
        }

        async Task _initBeneficiaries()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS beneficiaries (
                Id VARCHAR(50) PRIMARY KEY DEFAULT gen_random_uuid(),
                UserId VARCHAR(50) NOT NULL,
                CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                UpdatedAt TIMESTAMP,
                DeletedAt TIMESTAMP,
                SocialHelpId VARCHAR(50) REFERENCES socialhelps(Id) NOT NULL);
            """;
            await connection.ExecuteAsync(sql);
        }
    }
    }
}