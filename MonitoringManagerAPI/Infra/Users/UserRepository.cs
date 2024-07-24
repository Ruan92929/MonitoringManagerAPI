using MonitoringManagerAPI.Data;
using MonitoringManagerAPI.Domain;
using Dapper;

namespace MonitoringManagerAPI.Infra.Users
{
    public class UserRepository : IUserRepository
    {
        private DbSession _dbSession;
        public UserRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task CreateAsync(User user)
        {
            using (var conn = _dbSession.connection)
            {
                string qry = @"
                    INSERT INTO Users (Username, PasswordHash, Role, Email, EmployeeId) 
                    VALUES (@Username, @PasswordHash, @Role, @Email, @EmployeeId); 
                    SELECT SCOPE_IDENTITY();";


                var insertedId = await conn.QueryFirstOrDefaultAsync<int>(qry, user);
                user.Id = insertedId;
            }
        }

        public async Task<User> GetUserByName(string username)
        {
            using (var conn = _dbSession.connection)
            {
                string qry = "SELECT * FROM Users WHERE Username = @Username";
                return await conn.QueryFirstOrDefaultAsync<User>(qry, new { Username = username });
            }
        }
    }
}
