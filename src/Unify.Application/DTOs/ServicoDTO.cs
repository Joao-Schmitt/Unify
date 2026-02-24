namespace Unify.Application.DTOs
{
    public class ServicoDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoBase { get; set; }
        public int TempoMedioMinutos { get; set; }
        public string Observacoes { get; set; }
        public bool Ativo { get; set; }
    }
}
