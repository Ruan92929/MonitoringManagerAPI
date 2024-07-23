using MonitoringManagerAPI.Domain;
using MonitoringManagerAPI.Domain.DTOs;

namespace MonitoringManagerAPI.Service.Users
{
    public interface IUserService
    {
        Task Register(RegisterDTO register);
        Task<User> GetUserByName(string username);

    }
}
