using System.Data;
using Dapper;
using socialHelp.Entities;
using socialHelp.Helpers;

namespace socialHelp.Repositories
{
    public interface ISocialHelpRepository
    {
        Task<SocialHelp> GetOne(string id);
        Task<IEnumerable<SocialHelp>> GetAll();
        Task Create(SocialHelp socialHelp);
        Task Update(SocialHelp socialHelp);
        Task Delete(string id);
    }
    public class SocialHelpRepository : ISocialHelpRepository
    {
        private readonly DataContext _context;

        public SocialHelpRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<SocialHelp> GetOne(string id) {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """ SELECT * FROM socialHelps WHERE Id = @id AND DeletedAt IS NULL; """;
            return await connection.QuerySingleOrDefaultAsync<SocialHelp>(sql, new { id });
        }

        public async Task<IEnumerable<SocialHelp>> GetAll() {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                SELECT *
                FROM socialHelps WHERE deletedat IS NULL;
            """;
            return await connection.QueryAsync<SocialHelp>(sql);
        }

        public async Task Create(SocialHelp socialHelp) {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                INSERT INTO socialHelps (Id, Name, Description, LocationType, LocationId, DateActivation, DateExpiration, CreatedAt, UpdatedAt, DeletedAt)
                VALUES (gen_random_uuid(), @Name, @Description, @LocationType, @LocationId, @DateActivation, @DateExpiration, NOW(), NULL, NULL);
            """;
            await connection.ExecuteAsync(sql, socialHelp);
        }


        public async Task Update(SocialHelp socialHelp)
        {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                UPDATE socialHelps 
                SET Name = @Name,
                    Description = @Description,
                    LocationType = @LocationType,
                    LocationId = @LocationId,
                    DateActivation = @DateActivation,
                    DateExpiration = @DateExpiration,
                    UpdatedAt = NOW(),
                WHERE Id = @Id
            """;
            await connection.ExecuteAsync(sql, socialHelp);
        }

        public async Task Delete(string id)
        {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """UPDATE socialHelps SET DeletedAt = NOW() WHERE Id = @id; """;
            await connection.ExecuteAsync(sql, new { id });
        }
    }
}