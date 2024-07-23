namespace MonitoringManagerAPI.Domain
{
    /// <summary>
    /// Representa um operador monitorado pelo sistema.
    /// </summary>
    public class Operator
    {
        /// <summary>
        /// Identificador único do operador.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador do usuário associado ao operador.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Objeto usuário associado ao operador.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Nome do operador.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identificador do supervisor responsável pelo operador.
        /// </summary>
        public int SupervisorId { get; set; }

        /// <summary>
        /// Objeto usuário do supervisor responsável pelo operador.
        /// </summary>
        public User Supervisor { get; set; }
    }
}
