using MonitoringManagerAPI.Domain;

namespace MonitoringManagerAPI.Infra.Users
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task<User> GetUserByName(string username);
    }
}
