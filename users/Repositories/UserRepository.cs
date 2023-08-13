using Dapper;
using users.Entities;
using users.Helpers;

namespace users.Repositories
{

    public interface IUsersRepository
    {
        /*Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        */
        Task<User> GetByEmail(string email);
        Task<User> Login(string email, string password);
        Task Create(User user);
        Task LoggingAction(LoggingActions action);

        Task<IEnumerable<LoggingActions>> GetLoggingAction(string email, string dateAction);
        /*Task Update(User user);
        Task Delete(int id);*/
    }
    public class UsersRepository:  IUsersRepository {
        private readonly DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(User user) {
            using var connection = _context.CreateConnection();
            var sql = """
                INSERT INTO Users (Id, Name, LastName, Email, Role, PasswordHash, CommuneId)
                VALUES (gen_random_uuid(),@Name, @LastName, @Email, @Role, @PasswordHash, @CommuneId)
            """;
            await connection.ExecuteAsync(sql, user);
        }

        public async Task<User> GetByEmail(string email){
            using var connection = _context.CreateConnection();
            var sql = """
                SELECT * FROM Users 
                WHERE Email = @email
            """;
            return await connection.QuerySingleOrDefaultAsync<User>(sql, new { email });
        }
        public async Task<User> Login(string email, string password){
            using var connection = _context.CreateConnection();
            var sql = """
                SELECT * FROM Users 
                WHERE Email = @email AND PasswordHash = @password
            """;
            return await connection.QuerySingleOrDefaultAsync<User>(sql, new { email, password });
        }

        public async Task LoggingAction(LoggingActions action) {
            using var connection = _context.CreateConnection();
            var sql = """
                INSERT INTO UsersLog (Id, Type, Description, UserId, CreatedAt)
                VALUES (gen_random_uuid(),@Type, @Description, @UserId, NOW())
            """;
            await connection.ExecuteAsync(sql, action);
        }
        public async Task<IEnumerable<LoggingActions>> GetLoggingAction(string userId, string dateAction) {
            using var connection = _context.CreateConnection();
            string formatDate = dateAction + "%";
            var sql = """ SELECT * FROM userslog WHERE userid = @userId AND createdat::text LIKE @formatDate """;
            return await connection.QueryAsync<LoggingActions>(sql, new {userId, formatDate});
        }

    }
}