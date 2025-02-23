﻿using MonitoringManagerAPI.Data;
using MonitoringManagerAPI.Domain;
using Dapper;
using MonitoringManagerAPI.Domain.Enums;

namespace MonitoringManagerAPI.Infra.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context) => _context = context;


        public bool ExistUser(string username)
        {
            using (var conn = _context.CreateConnection())
            {
                string qry = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                var count = conn.QueryFirstOrDefault<int>(qry, new { Username = username });
                return count > 0;
            }
        }
        public bool ExistEmail(string email)
        {
            using (var conn = _context.CreateConnection())
            {
                string qry = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                var count = conn.QueryFirstOrDefault<int>(qry, new { Email = email });
                return count > 0;
            }
        }

        public async Task CreateAsync(User user)
        {
            using (var conn = _context.CreateConnection())
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
            using (var conn = _context.CreateConnection())
            {
                string qry = "SELECT * FROM Users WHERE Username = @Username";
                return await conn.QueryFirstOrDefaultAsync<User>(qry, new { Username = username });
            }
        }

        public async Task UpdateAsync(User user)
        {
            using (var conn = _context.CreateConnection())
            {
                string qry = @"
            UPDATE Users 
            SET Username = @Username, PasswordHash = @PasswordHash, Email = @Email, Role = @Role, EmployeeId = @EmployeeId
            WHERE Id = @Id";

                await conn.ExecuteAsync(qry, user);
            }
        }

        public async Task DeleteAsync(int userId)
        {
            using (var conn = _context.CreateConnection())
            {
                string qry = "DELETE FROM Users WHERE Id = @Id";
                await conn.ExecuteAsync(qry, new { Id = userId });
            }
        }

        public async Task<User> GetUserById(int userId)
        {
            using (var conn = _context.CreateConnection())
            {
                string qry = "SELECT * FROM Users WHERE Id = @Id";
                return await conn.QueryFirstOrDefaultAsync<User>(qry, new { Id = userId });
            }
        }


    }
}
