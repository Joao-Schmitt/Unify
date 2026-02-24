using System;
using System.Collections.Generic;
using Unify.Domain.Entities;

namespace Unify.Domain.Interfaces
{
    public interface IOrcamentoMaterialRepository : IRepository<OrcamentoMaterial>
    {
        IEnumerable<OrcamentoMaterial> ObterTodos();
    }
}
