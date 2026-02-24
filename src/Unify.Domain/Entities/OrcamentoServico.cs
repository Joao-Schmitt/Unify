using Unify.Domain.Abstractions;

namespace Unify.Domain.Entities
{
    public class OrcamentoServico : Entity
    {
        public OrcamentoServico() { }
        public OrcamentoServico(long id, long orcamentoId, long servicoId, decimal preco, int quantidade, decimal precoTotal, string observacoes)
        {
            Id = id;
            OrcamentoId = orcamentoId;
            ServicoId = servicoId;
            Preco = preco;
            Quantidade = quantidade;
            PrecoTotal = precoTotal;
            Observacoes = observacoes;
        }

        public long Id { get; set; }
        public long OrcamentoId { get; set; }
        public long ServicoId { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoTotal { get; set; }
        public string Observacoes { get; set; }

        public void AlterarServico(long servicoId)
        {
            this.ServicoId = servicoId;
        }

        public void AlterarPreco(decimal preco)
        {
            this.Preco = preco;
            AtualizaTotais();
        }

        public void AlterarQuantidade(int quantidade)
        {
            this.Quantidade = quantidade;
            AtualizaTotais();
        }

        public void AlterarObservacoes(string observacoes)
        {
            this.Observacoes = observacoes;
        }

        private void AtualizaTotais()
        {
            this.PrecoTotal = this.PrecoTotal * this.Quantidade;
        }
    }
}
