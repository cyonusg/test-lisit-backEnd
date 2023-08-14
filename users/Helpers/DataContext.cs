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
        await _initUsers();
        await _initUsersLogs();

        async Task _initUsers()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS Users (
                    Id VARCHAR(100) PRIMARY KEY,
                    Name VARCHAR(100),
                    LastName VARCHAR(100),
                    Email VARCHAR(50),
                    Role INTEGER,
                    CommuneId VARCHAR(100),
                    PasswordHash VARCHAR(200));
            """;
            await connection.ExecuteAsync(sql);
        }

        async Task _initUsersLogs()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS UsersLog (
                    Id VARCHAR(100) PRIMARY KEY,
                    Type VARCHAR(20),
                    Description TEXT,
                    UserId VARCHAR(100),
                    CreatedAt TIMESTAMP);
            """;
            await connection.ExecuteAsync(sql);
        }
    }
    }
}