using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;

namespace users.Helpers
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
        // create database if it doesn't exist
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
        // create tables if they don't exist
        using var connection = this.CreateConnection();
        await _initCountries();
        await _initRegions();
        await _initCommunes();

        async Task _initCountries()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS countries (
                Id VARCHAR(50) PRIMARY KEY DEFAULT gen_random_uuid(),
                Name VARCHAR(255) NOT NULL,
                CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                DeletedAt TIMESTAMP);
            """;
            await connection.ExecuteAsync(sql);
        }

        async Task _initRegions()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS regions (
                Id VARCHAR(50) PRIMARY KEY DEFAULT gen_random_uuid(),
                Name VARCHAR(255) NOT NULL,
                CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                DeletedAt TIMESTAMP,
                CountryId VARCHAR REFERENCES countries(Id));
            """;
            await connection.ExecuteAsync(sql);
        }
        async Task _initCommunes()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS communes (
                Id VARCHAR(50) PRIMARY KEY DEFAULT gen_random_uuid(),
                Name VARCHAR(255) NOT NULL,
                CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                DeletedAt TIMESTAMP,
                RegionId VARCHAR REFERENCES regions(Id));
            """;
            await connection.ExecuteAsync(sql);
        }
    }
    }
}