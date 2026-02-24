using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unify.Domain.Abstractions;
using Unify.Domain.Exceptions;

namespace Unify.Domain.Entities
{
    public class Servico : Entity
    {
        public Servico() { }
        public Servico(string nome, decimal precoBase, int tempoMedioMinutos, string observacoes, bool ativo)
        {
            Nome = nome;
            PrecoBase = precoBase;
            TempoMedioMinutos = tempoMedioMinutos;
            Observacoes = observacoes;
            Ativo = ativo;
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoBase { get; set; }
        public int TempoMedioMinutos { get; set; }
        public string Observacoes { get; set; }
        public bool Ativo { get; set; }


        public void AlterarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ValidationException("Nome obrigatório");

            this.Nome = nome;
        }

        public void AlterarPrecoBase(decimal preco)
        {
            if (preco <= 0)
                throw new ValidationException("Preço deve ser maior que zero");

            this.PrecoBase = preco;
        }

        public void AlterarTempoMedioMinutos(int minutos)
        {
            if (minutos <= 0)
                throw new ValidationException("Tempo médio deve ser maior que zero");

            this.TempoMedioMinutos = minutos;
        }

        public void AlterarObservacao(string observacao)
        {
            this.Observacoes = observacao;
        }

        public void AlterarStatusAtivo(bool ativo)
        {
            this.Ativo = ativo;
        }
    }
}
