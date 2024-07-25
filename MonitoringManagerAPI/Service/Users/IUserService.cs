using MonitoringManagerAPI.Domain;
using MonitoringManagerAPI.Domain.DTOs;
using MonitoringManagerAPI.Extensions.Validate;

namespace MonitoringManagerAPI.Service.Users
{
    public interface IUserService
    {
        Task Register(RegisterDTO register);
        Task<User> GetUserByName(string username);
        Task EditUser(string username, EditUserDTO editModel);
        Task DeleteUser(string username);
        Task<User> GetUserById(int userId);

    }
}
