using Microsoft.Win32;
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

        public void Exist(UserDTO register)
        {
            if (_userRepository.ExistUser(register.Username))
                throw new InvalidOperationException("Este usuário já foi cadastrado em sistema.");

            if (_userRepository.ExistEmail(register.Email))
                throw new InvalidOperationException("Este endereço de Email já foi cadastrado em sistema.");
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


        public async Task Register(UserDTO register)
        {
            Exist(register);

            UserValidationService.ValidateUser(register);


            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(register.PasswordHash);

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

        public async Task EditUser(int id, UserDTO editModel)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            UserValidationService.ValidateUser(editModel);

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(editModel.PasswordHash);

            user.Username = editModel.Username;
            user.PasswordHash = hashedPassword;
            user.Role = (Role)editModel.Role;
            user.Email = editModel.Email;
            user.EmployeeId = editModel.EmployeeId;

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            await _userRepository.DeleteAsync(user.Id);
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = await _userRepository.GetUserById(userId);

            if (user == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            return user;
        }

    }
}
