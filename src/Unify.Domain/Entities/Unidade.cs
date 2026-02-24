using Unify.Domain.Abstractions;
using Unify.Domain.Exceptions;

namespace Unify.Domain.Entities
{
    public class Unidade : Entity
    {
        public Unidade() { }
        public Unidade(string sigla, string descricao)
        {
            Sigla = sigla;
            Descricao = descricao;
        }

        public long Id { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }

        public void AlterarSigla(string sigla)
        {
            if (string.IsNullOrWhiteSpace(sigla))
                throw new ValidationException("Sigla obrigatório");

            this.Sigla = sigla;
        }

        public void AlterarDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ValidationException("Descrição obrigatório");

            this.Descricao = descricao;
        }
    }
}
