using MonitoringManagerAPI.Domain;
using MonitoringManagerAPI.Domain.DTOs;
using MonitoringManagerAPI.Extensions.Validate;

namespace MonitoringManagerAPI.Service.Users
{
    public interface IUserService
    {
        Task Register(UserDTO register);
        Task<User> GetUserByName(string username);
        Task EditUser(int id, UserDTO editModel);
        Task DeleteUser(int id);
        Task<User> GetUserById(int userId);

    }
}
