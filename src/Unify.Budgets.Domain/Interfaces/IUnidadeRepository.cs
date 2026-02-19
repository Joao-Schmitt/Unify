using System.Collections.Generic;
using Unify.Budgets.Domain.Entities;

namespace Unify.Budgets.Domain.Interfaces
{
    public interface IUnidadeRepository : IRepository<Unidade>
    {
        IEnumerable<Unidade> ObterTodos();
        bool ExisteComMesmaSigla(string sigla, long? ignorarId = null);
    }
}
