using System;
using System.Collections.Generic;
using Unify.Budgets.Domain.Entities;

namespace Unify.Budgets.Domain.Interfaces
{
    public interface IOrcamentoMaterialRepository : IRepository<OrcamentoMaterial>
    {
        IEnumerable<OrcamentoMaterial> ObterTodos();
    }
}
