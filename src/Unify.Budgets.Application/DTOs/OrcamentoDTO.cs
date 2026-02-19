using System;
using System.Security.Cryptography;
using Unify.Budgets.Domain.Enums;

namespace Unify.Budgets.Application.DTOs
{
    public class OrcamentoDTO
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public long SituacaoId { get; set; }
        public long UsuarioId { get; set; }
        public DateTime Dt_Criacao { get; set; }
        public DateTime Dt_Validade { get; set; }
        public DateTime Dt_PrazoFinalizacao { get; set; }
        public DateTime Dt_PrazoGarantia { get; set; }
        public decimal ValorTotal { get; set; }
    }

    public class OrcamentoDetalhadoDTO : OrcamentoDTO
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string SituacaoDescricao { get; set; }
    }
}
