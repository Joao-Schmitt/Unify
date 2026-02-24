using System.Collections.Generic;
using Unify.Domain.Entities;

namespace Unify.Domain.Interfaces
{
    public interface IUnidadeRepository : IRepository<Unidade>
    {
        IEnumerable<Unidade> ObterTodos();
        bool ExisteComMesmaSigla(string sigla, long? ignorarId = null);
    }
}
