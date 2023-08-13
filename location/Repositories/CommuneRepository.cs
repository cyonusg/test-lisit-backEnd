using System.Data;
using Dapper;
using location.Entities;
using users.Helpers;

namespace location.Repositories
{
    public interface ICommuneRepository
    {
        Task<Commune> GetOne(string id);
        Task<IEnumerable<Commune>> GetAll();
        Task<IEnumerable<Commune>> GetByRegionId(string RegionId);
        Task Create(Commune commune);
        Task Update(Commune commune);
        Task Delete(string id);
    }
    public class CommuneRepository : ICommuneRepository
    {
        private readonly DataContext _context;
        public CommuneRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Commune> GetOne(string id) {
            using IDbConnection connection = _context.CreateConnection();
            var sql = """ SELECT * FROM communes WHERE Id = @id AND DeletedAt IS NULL """;
            return await connection.QuerySingleOrDefaultAsync<Commune>(sql, new { id });
        }

        public async Task<IEnumerable<Commune>> GetAll() {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                SELECT *
                FROM communes WHERE DeletedAt IS NULL
            """;
            return await connection.QueryAsync<Commune>(sql);
        }

        public async Task<IEnumerable<Commune>> GetByRegionId(string RegionId) {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                SELECT *
                FROM communes WHERE RegionId = @RegionId AND DeletedAt IS NULL;
            """;
            return await connection.QueryAsync<Commune>(sql, new { RegionId });
        }

        public async Task Create(Commune commune) {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                INSERT INTO communes (Id, Name, RegionId, CreatedAt, UpdatedAt, DeletedAt)
                VALUES (gen_random_uuid(), @Name, @RegionId, NOW(), NULL, NULL);
            """;
            await connection.ExecuteAsync(sql, commune);
        }

        public async Task Update(Commune commune)
        {
            using var connection = _context.CreateConnection();
            var sql = """
                UPDATE communes 
                SET Name = @Name,
                    RegionId = @RegionId
                    UpdatedAt = NOW(),
                WHERE Id = @Id
            """;
            await connection.ExecuteAsync(sql, commune);
        }

        public async Task Delete(string id)
        {
            using var connection = _context.CreateConnection();
            var sql = """UPDATE communes SET DeletedAt = NOW() WHERE Id = @id; """;
            await connection.ExecuteAsync(sql, new { id });
        }
    }
}