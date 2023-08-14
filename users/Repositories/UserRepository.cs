using System.Data;
using Dapper;
using users.Entities;
using users.Helpers;
using users.Models.Users;

namespace users.Repositories
{

    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetByEmail(string email);
        Task<User> Login(string email, string password);
        Task Create(User user);
        Task LoggingAction(LoggingActions action);
        Task<IEnumerable<LoggingActions>> GetLoggingAction(string email, string dateAction);
        Task Delete(string email);
        /*Task Update(User user);*/
    }
    public class UsersRepository:  IUsersRepository {
        private readonly DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll() {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                SELECT *
                FROM users WHERE deletedat IS NULL;
            """;
            return await connection.QueryAsync<User>(sql);
        }

        public async Task<User> GetByEmail(string email){
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                SELECT * FROM Users 
                WHERE Email = @email
            """;
            return await connection.QuerySingleOrDefaultAsync<User>(sql, new { email });
        }

        public async Task Create(User user) {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                INSERT INTO users (Id, Name, LastName, Email, Role, PasswordHash, CommuneId, CreatedAt, UpdatedAt, DeletedAt)
                VALUES (gen_random_uuid(),@Name, @LastName, @Email, @Role, @PasswordHash, @CommuneId, NOW(), NULL, NULL)
            """;
            await connection.ExecuteAsync(sql, user);
        }

        public async Task<User> Login(string email, string password){
            using IDbConnection connection = _context.CreateConnection();
            string sql = """
                SELECT * FROM users 
                WHERE Email = @email AND PasswordHash = @password
            """;
            return await connection.QuerySingleOrDefaultAsync<User>(sql, new { email, password });
        }

        public async Task LoggingAction(LoggingActions action){
            using IDbConnection connection = _context.CreateConnection();
            string sql = """ INSERT INTO userslog (Id, Type, Description, UserId, CreatedAt) VALUES (gen_random_uuid(), @Type, @Description, @UserId, NOW()); """;
            await connection.ExecuteAsync(sql, action);
        }

        public async Task<IEnumerable<LoggingActions>> GetLoggingAction(string userId, string dateAction) {
            using IDbConnection connection = _context.CreateConnection();
            string formatDate = dateAction + "%";
            string sql = """ SELECT * FROM userslog WHERE userid = @userId AND createdat::text LIKE @formatDate """;
            return await connection.QueryAsync<LoggingActions>(sql, new {userId, formatDate});
        }

        public async Task Delete(string email)
        {
            using IDbConnection connection = _context.CreateConnection();
            string sql = """UPDATE users SET DeletedAt = NOW() WHERE Email = @email; """;
            await connection.ExecuteAsync(sql, new { email });
        }
    }
}