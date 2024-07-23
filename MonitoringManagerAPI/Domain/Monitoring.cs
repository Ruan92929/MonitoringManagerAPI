namespace MonitoringManagerAPI.Domain
{
    /// <summary>
    /// Representa uma monitoria realizada por um monitor em um operador.
    /// </summary>
    public class Monitoring
    {
        /// <summary>
        /// Identificador único da monitoria.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador do monitor que realizou a monitoria.
        /// </summary>
        public int MonitorId { get; set; }

        /// <summary>
        /// Objeto usuário do monitor que realizou a monitoria.
        /// </summary>
        public User Monitor { get; set; }

        /// <summary>
        /// Identificador do operador que foi monitorado.
        /// </summary>
        public int OperatorId { get; set; }

        /// <summary>
        /// Objeto operador que foi monitorado.
        /// </summary>
        public Operator Operator { get; set; }

        /// <summary>
        /// Data e hora em que a monitoria foi realizada.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Nota total atribuída ao operador na monitoria.
        /// </summary>
        public decimal TotalScore { get; set; }

        /// <summary>
        /// Comentários adicionais feitos pelo monitor.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Indica se o operador aprovou ou não a monitoria.
        /// </summary>
        public bool ApprovedByOperator { get; set; }

        /// <summary>
        /// Feedback dado pelo operador em relação à monitoria.
        /// </summary>
        public string OperatorFeedback { get; set; }

        /// <summary>
        /// Itens de checklist associados a esta monitoria.
        /// </summary>
        public ICollection<ChecklistItem> ChecklistItems { get; set; }
    }
}
