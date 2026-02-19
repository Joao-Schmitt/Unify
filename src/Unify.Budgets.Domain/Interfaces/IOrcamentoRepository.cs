using System;
using System.Collections.Generic;
using Unify.Budgets.Domain.Entities;

namespace Unify.Budgets.Domain.Interfaces
{
    public interface IOrcamentoRepository : IRepository<Orcamento>
    {
        IEnumerable<Orcamento> ObterTodos();
    }
}
