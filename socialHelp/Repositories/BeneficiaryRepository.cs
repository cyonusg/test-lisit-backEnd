using System.Data;
using Dapper;
using socialHelp.Entities;
using socialHelp.Helpers;

namespace socialHelp.Repositories
{

    public interface IBeneficiaryRepository
    {
        Task<Beneficiary> GetOne(string socialHelpId, string userId);
        Task<IEnumerable<Beneficiary>> GetAll(string socialHelpId);
        Task Create(Beneficiary beneficiary);

        //Task Update(Beneficiary beneficiary);
        Task Delete(string socialHelpId, string userId);
        Task<Beneficiary> ValidateBeneficiary(string socialHelpId, string userId, string yearActivation, string yearExpiration);
        Task DeleteCascade(string socialHelpId);
    }
    public class BeneficiaryRepository : IBeneficiaryRepository
    {
        private readonly DataContext _context;

        public BeneficiaryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Beneficiary> GetOne(string socialHelpId, string userId) {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """ SELECT * FROM beneficiaries WHERE socialHelpId = @socialHelpId AND userId = @userId AND DeletedAt IS NULL; """;
            return await connection.QuerySingleOrDefaultAsync<Beneficiary>(sql, new { socialHelpId, userId});
        }
        public async Task<IEnumerable<Beneficiary>> GetAll(string socialHelpId) {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """ SELECT * FROM beneficiaries WHERE socialHelpId = @socialHelpId AND DeletedAt IS NULL; """;
            return await connection.QueryAsync<Beneficiary>(sql, new { socialHelpId});
        }

        public async Task<Beneficiary> ValidateBeneficiary(string socialHelpId, string userId, string yearActivation, string yearExpiration) {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """ SELECT * FROM beneficiaries WHERE DeletedAt IS NULL AND (createdAt::text LIKE @yearActivation OR createdAt::text LIKE @yearExpiration ); """;
            return await connection.QuerySingleOrDefaultAsync<Beneficiary>(sql, new { socialHelpId, userId, yearActivation, yearExpiration});
        }
        public async Task Create(Beneficiary beneficiary) {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                INSERT INTO beneficiaries (Id, UserId, SocialHelpId, CreatedAt, UpdatedAt, DeletedAt)
                VALUES (gen_random_uuid(), @UserId, @SocialHelpId, NOW(), NULL, NULL);
            """;
            await connection.ExecuteAsync(sql, beneficiary);
        }

        public async Task Delete(string socialHelpId, string userId)
        {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """UPDATE beneficiaries SET DeletedAt = NOW() WHERE socialHelpId = @socialHelpId AND userId = @userId; """;
            await connection.ExecuteAsync(sql, new { socialHelpId, userId });
        }

        public async Task DeleteCascade(string socialHelpId) {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """UPDATE beneficiaries SET DeletedAt = NOW() WHERE socialHelpId = @socialHelpId; """;
            await connection.ExecuteAsync(sql, new { socialHelpId });
        }
    }
}