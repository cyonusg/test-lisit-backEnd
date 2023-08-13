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
    public interface IRegionRepository
    {
        Task<Region> GetOne(string id);
        Task<IEnumerable<Region>> GetAll();
        Task<IEnumerable<Region>> GetByCountryId(string countryId);
        Task Create(Region region);
        Task Update(Region region);
        Task Delete(string id);
    }

    public class RegionRepository : IRegionRepository
    {
        private readonly DataContext _context;

        public RegionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Region> GetOne(string id) {
            using IDbConnection connection = _context.CreateConnection();
            var sql = """ SELECT * FROM regions WHERE Id = @id AND DeletedAt IS NULL; """;
            return await connection.QuerySingleOrDefaultAsync<Region>(sql, new { id });
        } 
        public async Task<IEnumerable<Region>> GetAll() {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                SELECT Id, Name, CreatedAt, UpdatedAt
                FROM regions
                WHERE DeletedAt IS NULL;
            """;
            return await connection.QueryAsync<Region>(sql);
        } 
        public async Task<IEnumerable<Region>> GetByCountryId(string countryId) {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                SELECT Id, Name
                FROM regions
                WHERE DeletedAt IS NULL;
            """;
            return await connection.QueryAsync<Region>(sql);
        } 
        public async Task Create(Region region) {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                INSERT INTO regions (Id, Name, CountryId, CreatedAt, UpdatedAt, DeletedAt)
                VALUES (gen_random_uuid(), @Name, @CountryId, NOW(), NULL, NULL);
            """;
            await connection.ExecuteAsync(sql, region);
        }

        public async Task Update(Region region)
        {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                UPDATE regions 
                SET Name = @Name,
                    CountryId = @CountryId
                    UpdatedAt = NOW(),
                WHERE Id = @Id
            """;
            await connection.ExecuteAsync(sql, region);
        }

        public async Task Delete(string id)
        {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """UPDATE regions SET DeletedAt = NOW() WHERE Id = @id; """;
            await connection.ExecuteAsync(sql, new { id });
        }
    }
}