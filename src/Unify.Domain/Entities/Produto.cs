using System;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using Unify.Domain.Abstractions;
using Unify.Domain.Exceptions;

namespace Unify.Domain.Entities
{
    public class Produto : Entity
    {
        public Produto() { }
        public Produto(string nome, string unidade, decimal precoUnidade, bool ativo)
        {
            this.Nome = nome;
            this.Unidade = unidade;
            this.PrecoUnidade = precoUnidade;
            this.Ativo = ativo;
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public decimal PrecoUnidade { get; set; }
        public bool Ativo { get; set; }

        public void AlterarNome(string nome)
        {
            if(string.IsNullOrWhiteSpace(nome))
                throw new ValidationException("Nome obrigatório");

            this.Nome = nome;
        }

        public void AlterarUnidade(string unidade)
        {
            if(string.IsNullOrWhiteSpace(unidade))
                throw new ValidationException("Unidade obrigatória");

            if(unidade.Length > 3)
                throw new ValidationException("Unidade inválida");

            this.Unidade = unidade;
        }

        public void AlterarPrecoUnidade(decimal preco)
        {
            if (preco <= 0)
                throw new ValidationException("Preço deve ser maior que zero");

            this.PrecoUnidade = preco;
        }

        public void AlterarStatusAtivo(bool ativo)
        {
            this.Ativo = ativo;
        }

    }
}
