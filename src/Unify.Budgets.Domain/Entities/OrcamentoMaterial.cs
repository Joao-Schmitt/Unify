using Unify.Budgets.Domain.Abstractions;
using Unify.Budgets.Domain.Exceptions;

namespace Unify.Budgets.Domain.Entities
{
    public class OrcamentoMaterial : Entity
    {
        public OrcamentoMaterial() { }
        public OrcamentoMaterial(long id, long orcamentoId, long produtoId, decimal comprimento, decimal largura, decimal areaTotal, decimal precoUnidade, decimal quantidade, decimal precoTotal, string observacoes)
        {
            Id = id;
            OrcamentoId = orcamentoId;
            ProdutoId = produtoId;
            Comprimento = comprimento;
            Largura = largura;
            AreaTotal = areaTotal;
            PrecoUnidade = precoUnidade;
            Quantidade = quantidade;
            PrecoTotal = precoTotal;
            Observacoes = observacoes;
        }

        public long Id { get; set; }
        public long OrcamentoId { get; set; }
        public long ProdutoId { get; set; }
        public decimal Comprimento { get; set; }
        public decimal Largura { get; set; }
        public decimal AreaTotal { get; set; }
        public decimal PrecoUnidade { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoTotal { get; set; }
        public string Observacoes { get; set; }

        public void AlterarProduto(long produtoId)
        {
            this.ProdutoId = produtoId;
        }

        public void AlterarComprimento(decimal comprimento)
        {
            if(comprimento <= 0)
                throw new ValidationException("Comprimento inválido!");

            this.Comprimento = comprimento;
            AtualizaTotais();
        }

        public void AlterarLargura(decimal largura)
        {
            if (largura <= 0)
                throw new ValidationException("Largura inválida!");

            this.Largura = largura;
            AtualizaTotais();
        }

        public void AlterarPrecoUnidade(decimal preco)
        {
            this.PrecoUnidade = preco;
        }

        public void AlterarQuantidade(decimal quantidade)
        {
            this.Quantidade = quantidade;
            AtualizaTotais();
        }

        public void AlterarObservacoes(string obs)
        {
            this.Observacoes = obs;
        }

        private void AtualizaTotais()
        {
            this.AreaTotal = this.Comprimento * this.Largura;
            this.PrecoTotal = (this.PrecoUnidade * this.AreaTotal) * this.Quantidade;
        }
    }
}
    