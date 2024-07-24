using MonitoringManagerAPI.Domain.Enums;
using System.Data;

namespace MonitoringManagerAPI.Domain
{
     /// <summary>
    /// Representa um usuário no sistema, que pode ser um monitor ou operador.
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string EmployeeId { get; set; }
    }
}
