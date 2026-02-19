using System;
using System.Collections.Generic;
using Unify.Budgets.Domain.Entities;

namespace Unify.Budgets.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> ObterTodos();
        bool ExisteComMesmoNome(string nome, long? ignorarId = null);
    }
}
