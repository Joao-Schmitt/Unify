namespace Unify.Budgets.Application.DTOs
{
    public class OrcamentoServicoDTO
    {
        public long Id { get; set; }
        public long OrcamentoId { get; set; }
        public long ServicoId { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoTotal { get; set; }
        public string Observacoes { get; set; }
    }
}
