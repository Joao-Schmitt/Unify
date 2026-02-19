using System;
using System.Collections.Generic;
using Unify.Budgets.Domain.Enums;

namespace Unify.Budgets.Application.DTOs
{
    public class OrcamentoDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public OrcamentoSituacao SituacaoId { get; set; }
        public long UsuarioId { get; set; }
        public DateTime Dt_Criacao { get; set; }
        public DateTime Dt_Prazo { get; set; }
        public decimal CustoTotal { get; set; }
        public decimal PrecoTotal { get; set; }
        public decimal LucroTotal { get; set; }
    }
}
