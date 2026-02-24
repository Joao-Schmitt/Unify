namespace Unify.Application.DTOs
{
    public class OrcamentoMaterialDTO
    {
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
    }

    public class OrcamentoMaterialDetalhadoDTO : OrcamentoMaterialDTO
    {
        public string NomeProduto { get; set; }
    }
}
