namespace MonitoringManagerAPI.Domain
{
    /// <summary>
    /// Representa um item de checklist avaliado durante uma monitoria.
    /// </summary>
    public class ChecklistItem
    {
        /// <summary>
        /// Identificador único do item de checklist.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador da monitoria a que este item pertence.
        /// </summary>
        public int MonitoringId { get; set; }

        /// <summary>
        /// Objeto monitoria a que este item pertence.
        /// </summary>
        public Monitoring Monitoring { get; set; }

        /// <summary>
        /// Descrição do item de checklist.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Nota atribuída para este item específico.
        /// </summary>
        public decimal Score { get; set; }
    }
}
