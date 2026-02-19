using Unify.Budgets.Domain.Abstractions;

namespace Unify.Budgets.Domain.Entities
{
    public class OrcamentoMaterial : Entity
    {
        public OrcamentoMaterial() { }
        public OrcamentoMaterial(long id, long orcamentoId, long produtoId, decimal quantidade, decimal precoTotal)
        {
            Id = id;
            OrcamentoId = orcamentoId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            PrecoTotal = precoTotal;
        }

        public long Id { get; set; }
        public long OrcamentoId { get; set; }
        public long ProdutoId { get; set; }
        public decimal PrecoUnidade { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoTotal { get; set; }

        public void AlterarProduto(long produtoId)
        {
            this.ProdutoId = produtoId;
        }

        public void AlterarPrecoUnidade(decimal preco)
        {
            this.PrecoUnidade = preco;
        }

        public void AlterarQuantidade(decimal quantidade)
        {
            this.Quantidade = quantidade;
        }

        public void AlterarPrecoTotal(decimal precoTotal)
        {
            this.PrecoTotal = precoTotal;
        }
    }
}
