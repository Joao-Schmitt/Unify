using Unify.Budgets.Domain.Abstractions;

namespace Unify.Budgets.Domain.Entities
{
    public class OrcamentoServico : Entity
    {
        public OrcamentoServico() { }
        public OrcamentoServico(long id, long orcamentoId, long servicoId, decimal precoBase, decimal tempoMedioMinutos, decimal precoTotal, string observacoes)
        {
            Id = id;
            OrcamentoId = orcamentoId;
            ServicoId = servicoId;
            PrecoBase = precoBase;
            TempoMedioMinutos = tempoMedioMinutos;
            PrecoTotal = precoTotal;
            Observacoes = observacoes;
        }

        public long Id { get; set; }
        public long OrcamentoId { get; set; }
        public long ServicoId { get; set; }
        public decimal PrecoBase { get; set; }
        public decimal TempoMedioMinutos { get; set; }
        public decimal PrecoTotal { get; set; }
        public string Observacoes { get; set; }

        public void AlterarServico(long servicoId)
        {
            this.ServicoId = servicoId;
        }

        public void AlterarPrecoBase(decimal preco)
        {
            this.PrecoBase = preco;
        }

        public void AlterarTempoMedio(decimal tempo)
        {
            this.TempoMedioMinutos = tempo;
        }

        public void AlterarPrecoTotal(decimal precoTotal)
        {
            this.PrecoTotal = precoTotal;
        }
        public void AlterarObservacoes(string observacoes)
        {
            this.Observacoes = observacoes;
        }
    }
}
