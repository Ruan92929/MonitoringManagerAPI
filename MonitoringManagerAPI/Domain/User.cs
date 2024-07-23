using MonitoringManagerAPI.Domain.Enums;
using System.Data;

namespace MonitoringManagerAPI.Domain
{
     /// <summary>
    /// Representa um usuário no sistema, que pode ser um monitor ou operador.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Identificador único do usuário.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome de usuário para login.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Hash da senha do usuário para segurança.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Papel do usuário no sistema (Monitor ou Operador).
        /// </summary>
        public Role Role { get; set; } // Pode ser "Monitor" ou "Operator"
    }
}
