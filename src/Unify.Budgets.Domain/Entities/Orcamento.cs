using System;
using Unify.Budgets.Domain.Abstractions;
using Unify.Budgets.Domain.Enums;
using Unify.Budgets.Domain.Exceptions;
using Unify.Budgets.Shared.Validations;

namespace Unify.Budgets.Domain.Entities
{
    public class Orcamento : Entity
    {
        public Orcamento() { }
        public Orcamento(long id, long clienteId, string rua, string cidade, string bairro, string numero, string estado, string cep, string complemento, long situacaoId, long usuarioId, DateTime dt_Criacao, DateTime dt_Validade, DateTime dt_PrazoFinalizacao, DateTime dt_PrazoGarantia, decimal valorTotal)
        {
            Id = id;
            ClienteId = clienteId;
            Rua = rua;
            Cidade = cidade;
            Bairro = bairro;
            Numero = numero;
            Estado = estado;
            CEP = cep;
            Complemento = complemento;
            SituacaoId = situacaoId;
            UsuarioId = usuarioId;
            Dt_Criacao = dt_Criacao;
            Dt_Validade = dt_Validade;
            Dt_PrazoFinalizacao = dt_PrazoFinalizacao;
            Dt_PrazoGarantia = dt_PrazoGarantia;
            ValorTotal = valorTotal;
        }


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

        public void AlterarCliente(long id)
        {
            if (id <= 0)
                throw new ValidationException("Cliente inválido!");

            this.ClienteId = id;
        }

        public void AlterarRua(string rua)
        {
            this.Rua = rua;
        }

        public void AlterarCidade(string cidade)
        {
            this.Cidade = cidade;
        }

        public void AlterarBairro(string bairro)
        {
            this.Bairro = bairro;
        }

        public void AlterarNumero(string numero)
        {
            this.Numero = numero;
        }

        public void AlterarEstado(string estado)
        {
            if (estado.Length > 2)
                throw new ValidationException("A sigla do estado informado é inválida!");

            this.Estado = estado;
        }

        public void AlterarCEP(string cep)
        {
            if (!Validations.ValidaCep(cep))
                throw new ValidationException("O cep informado é inválido!");

            this.CEP = cep;
        }

        public void AlterarSituacao(OrcamentoSituacao situacao)
        {
            this.SituacaoId = (long)situacao;
        }

        public void AlterarUsuarioCriador(long id)
        {
            if (id <= 0)
                throw new ValidationException("Usuário inválido!");

            this.UsuarioId = id;
        }

        public void AlterarDtCriacao(DateTime dt)
        {
            if (dt == DateTime.MinValue)
                throw new ValidationException("Prazo inválido!");

            this.Dt_Criacao = dt;
        }

        public void AlterarDtValidade(DateTime dt)
        {
            if (dt == DateTime.MinValue)
                throw new ValidationException("Validade inválida!");

            if(dt <= DateTime.Now)
                throw new ValidationException("Validade deve ser maior que a data atual!");

            this.Dt_Validade = dt;
        }

        public void AlterarDtPrazoFinalizacao(DateTime dt)
        {
            if (dt == DateTime.MinValue)
                throw new ValidationException("Prazo de finalização inválido!");

            if (dt <= DateTime.Now)
                throw new ValidationException("Prazo de finalização deve ser maior que a data atual!");

            this.Dt_PrazoFinalizacao = dt;
        }

        public void AlterarDtPrazoGarantia(DateTime dt)
        {
            if (dt == DateTime.MinValue)
                throw new ValidationException("Prazo de garantia inválido!");

            if (dt <= DateTime.Now)
                throw new ValidationException("Prazo de garantia deve ser maior que a data atual!");

            this.Dt_PrazoGarantia = dt;
        }

        public void AlterarValorTotal(decimal valor)
        {
            this.ValorTotal = valor;
        }
    }
}
