using System;
using System.Collections.Generic;
using Unify.Domain.Entities;

namespace Unify.Domain.Interfaces
{
    public interface IOrcamentoRepository : IRepository<Orcamento>
    {
        IEnumerable<Orcamento> ObterTodos();
    }
}
