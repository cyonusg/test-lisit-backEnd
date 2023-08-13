using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using location.Entities;
using users.Helpers;

namespace location.Repositories
{
    public interface ICountryRepository
    {
        Task<Country> GetOne(string id);
        Task<IEnumerable<Country>> GetAll();
        Task Create(Country country);
        Task Update(Country country);
        Task Delete(string id);
    }
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Country> GetOne(string id) {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """ SELECT * FROM countries WHERE Id = @id AND DeletedAt IS NULL; """;
            return await connection.QuerySingleOrDefaultAsync<Country>(sql, new { id });
        } 
        public async Task<IEnumerable<Country>> GetAll() {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                SELECT id, name
                FROM countries WHERE deletedat IS NULL;
            """;
            return await connection.QueryAsync<Country>(sql);
        } 
        public async Task Create(Country country) {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                INSERT INTO countries (Id, Name, CreatedAt, UpdatedAt, DeletedAt)
                VALUES (gen_random_uuid(), @Name, NOW(), NULL, NULL);
            """;
            await connection.ExecuteAsync(sql, country);
        }

        public async Task Update(Country country)
        {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                UPDATE countries 
                SET Name = @Name,
                    UpdatedAt = NOW(),
                WHERE Id = @Id
            """;
            await connection.ExecuteAsync(sql, country);
        }

        public async Task Delete(string id)
        {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """UPDATE countries SET DeletedAt = NOW() WHERE Id = @id; """;
            await connection.ExecuteAsync(sql, new { id });
        }
    }
}