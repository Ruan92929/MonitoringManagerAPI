using MonitoringManagerAPI.Domain.Enums;

namespace MonitoringManagerAPI.Domain.DTOs
{
    public class RegisterDTO
    {
        public string Username { get; set;}
        public string Password { get; set;}
        public string Email { get; set; }
        public string EmployeeId { get; set;}
        public int Role { get; set; } 

    }
}
