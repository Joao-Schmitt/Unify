using System.Collections.Generic;
using Unify.Budgets.Application.DTOs;

namespace Unify.Budgets.Application.Interfaces.Queries
{
    public interface IOrcamentoQueries
    {
        IEnumerable<OrcamentoDetalhadoDTO> ObterTodosDetalhado();
    }
}
