using users.Helpers;
using users.Models.Users;
using users.Repositories;
using encryptLib = BCrypt.Net.BCrypt;
using AutoMapper;
using users.Entities;

namespace users.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersService(IUsersRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }   
        public async Task Create(CreateRequest model) {
            LoggingActions action = new() {
                Type = "Created",
                Description = "Request to created user" + model.Email,
                UserId = "c024d9b5-ced2-4241-9f3e-fd11551d1018",
            };
            await _userRepository.LoggingAction(action);

            // validate
            if (await _userRepository.GetByEmail(model.Email!) != null)
                throw new AppException("User with the email '" + model.Email + "' already exists");

            User user = _mapper.Map<User>(model);

            user.PasswordHash = encryptLib.HashPassword(model.Password);

            await _userRepository.Create(user);
        }

        public async Task<User> FindOne(string email) {
                LoggingActions action = new() {
                Type = "GEt",
                Description = "Request to Get user" + email,
                UserId = "c024d9b5-ced2-4241-9f3e-fd11551d1018",
            };
            await _userRepository.LoggingAction(action);

            User user = await _userRepository.GetByEmail(email);
            // validate
            if (user == null)
                throw new AppException("User'" + email + "' not found exists");
            return user;
        }
        public async Task<User> Login(string email, string password) {
            LoggingActions action = new() {
                Type = "Login",
                Description = "Request to Login user" + email,
                UserId = "c024d9b5-ced2-4241-9f3e-fd11551d1018",
            };
            await _userRepository.LoggingAction(action);

            string passwordHash = encryptLib.HashPassword(password);
            User user = await _userRepository.Login(email,passwordHash);
            if (user == null)
                throw new AppException("Users or password Incorrect");

            return user;
        }
        
        public async Task<IEnumerable<LoggingActions>> UserAction (string id, string dateAction) {
           IEnumerable<LoggingActions> actions = await _userRepository.GetLoggingAction(id, dateAction);
            return actions;
        }
    }

    public interface IUsersService {
        Task Create(CreateRequest model);
        Task<User> Login(string email, string password);
        Task<User> FindOne(string email);

        Task<IEnumerable<LoggingActions>> UserAction (string email, string dateAction);
    }
}