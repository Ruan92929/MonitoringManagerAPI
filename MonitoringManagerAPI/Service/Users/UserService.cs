using MonitoringManagerAPI.Domain;
using MonitoringManagerAPI.Domain.DTOs;
using MonitoringManagerAPI.Domain.Enums;
using MonitoringManagerAPI.Extensions.Validate;
using MonitoringManagerAPI.Infra.Users;

namespace MonitoringManagerAPI.Service.Users
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<User> GetUserByName(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("O nome de usuário não pode ser vazio ou nulo.");
            }

            var user = await _userRepository.GetUserByName(username);
            return user;
        }


        public async Task Register(RegisterDTO register)
        {
            UserValidationService.ValidateRegister(register);


            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(register.Password);

            var user = new User
            {
                Username = register.Username,
                PasswordHash = hashedPassword,
                Role = (Role)register.Role,
                Email = register.Email,
                EmployeeId = register.EmployeeId
            };
            await _userRepository.CreateAsync(user);
        }


    }
}
