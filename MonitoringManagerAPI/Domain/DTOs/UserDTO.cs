using MonitoringManagerAPI.Domain.Enums;

namespace MonitoringManagerAPI.Domain.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public Role Role { get; set; } 
    }
}
