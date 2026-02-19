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
        public Orcamento(long id, string nome, string documento, string email, string telefone, string rua, string cidade, string bairro, string numero, string estado, string cEP, long situacaoId, long usuarioId, DateTime dt_Criacao, DateTime dt_Prazo, decimal custoTotal, decimal precoTotal, decimal lucroTotal)
        {
            Id = id;
            Nome = nome;
            Documento = documento;
            Email = email;
            Telefone = telefone;
            Rua = rua;
            Cidade = cidade;
            Bairro = bairro;
            Numero = numero;
            Estado = estado;
            CEP = cEP;
            SituacaoId = situacaoId;
            UsuarioId = usuarioId;
            Dt_Criacao = dt_Criacao;
            Dt_Prazo = dt_Prazo;
            CustoTotal = custoTotal;
            PrecoTotal = precoTotal;
            LucroTotal = lucroTotal;
        }

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
        public long SituacaoId { get; set; }
        public long UsuarioId { get; set; }
        public DateTime Dt_Criacao { get; set; }
        public DateTime Dt_Prazo { get; set; }
        public decimal CustoTotal { get; set; }
        public decimal PrecoTotal { get; set; }
        public decimal LucroTotal { get; set; }

        public void AlterarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ValidationException("Nome obrigatório");

            this.Nome = nome;
        }

        public void AlterarDocumento(string documento)
        {
            if (!string.IsNullOrWhiteSpace(documento))
            {
                if (documento.Length != 11 && documento.Length != 14)
                    throw new ValidationException("O documento informado não válido!");
            }

            this.Documento = documento;
        }

        public void AlterarEmail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!email.Contains("@"))
                    throw new ValidationException("O email informado é inválido!");
            }

            this.Email = email;
        }

        public void AlterarTelefone(string fone)
        {
            if (!Validations.ValidaFone(fone))
                throw new ValidationException("O telefone informado é inválido!");

            this.Telefone = fone;
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

        public void AlterarDtPrazo(DateTime dt)
        {
            if(dt == DateTime.MinValue)
                throw new ValidationException("Prazo inválido!");

            this.Dt_Prazo = dt;
        }

        public void AlterarCustoTotal(decimal valor)
        {
            this.CustoTotal = valor;
        }

        public void AlterarPrecoTotal(decimal valor)
        {
            this.PrecoTotal = valor;
        }

        public void AlterarLucroTotal(decimal valor)
        {
            this.LucroTotal = valor;
        }
    }
}
