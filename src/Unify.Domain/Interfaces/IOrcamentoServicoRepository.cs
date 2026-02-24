using System;
using System.Collections.Generic;
using Unify.Domain.Entities;

namespace Unify.Domain.Interfaces
{
    public interface IOrcamentoServicoRepository : IRepository<OrcamentoServico>
    {
        IEnumerable<OrcamentoServico> ObterTodos();
    }
}
