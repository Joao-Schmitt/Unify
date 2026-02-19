namespace Unify.Budgets.Application.DTOs
{
    public class ProdutoDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public string DescricaoUnidade { get; set; }
        public decimal PrecoUnidade { get; set; }
        public bool Ativo { get; set; }

        //
        public decimal Quantidade { get; set; }
    }
}
