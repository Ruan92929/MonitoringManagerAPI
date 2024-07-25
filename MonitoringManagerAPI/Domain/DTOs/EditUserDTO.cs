using MonitoringManagerAPI.Domain.Enums;

namespace MonitoringManagerAPI.Domain.DTOs
{
    public class EditUserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string EmployeeId { get; set; }
    }
}
