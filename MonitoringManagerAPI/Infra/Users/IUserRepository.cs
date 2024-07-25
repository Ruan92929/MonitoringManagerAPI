using MonitoringManagerAPI.Data;
using MonitoringManagerAPI.Domain;

namespace MonitoringManagerAPI.Infra.Users
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        //bool ExistUser(string username);
        //bool ExistEmail(string email);
        Task<User> GetUserByName(string username);
        Task UpdateAsync(User user);
        Task DeleteAsync(int userId);
        Task<User> GetUserById(int userId);



    }
}
