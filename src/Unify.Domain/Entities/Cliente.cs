using System;
using Unify.Domain.Abstractions;
using Unify.Domain.Exceptions;
using Unify.Shared.Validations;

namespace Unify.Domain.Entities
{
    public class Cliente : Entity
    {
        public Cliente() 
        { 
            Dt_Criacao = DateTime.Now; 
        }
        public Cliente(long id, string nome, string documento, string email, string telefone, string rua, string cidade, string bairro, string numero, string estado, string complemento, string cep, bool ativo, DateTime dt_Criacao): base()
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
            CEP = cep;
            Complemento = complemento;
            Ativo = ativo;
            Dt_Criacao = dt_Criacao;
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
        public string Complemento { get; set; }
        public bool Ativo { get; set; }
        public DateTime Dt_Criacao { get; set; }


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

        public void AlterarComplemento(string complemento)
        {
            this.Complemento = complemento;
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

        public void AlterarStatusAtivo(bool ativo)
        {
            this.Ativo = ativo;
        }
    }
}
