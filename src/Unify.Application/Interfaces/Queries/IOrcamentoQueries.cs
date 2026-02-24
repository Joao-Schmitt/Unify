using System.Collections.Generic;
using Unify.Application.DTOs;

namespace Unify.Application.Interfaces.Queries
{
    public interface IOrcamentoQueries
    {
        IEnumerable<OrcamentoDetalhadoDTO> ObterTodosDetalhado();
        IEnumerable<OrcamentoMaterialDetalhadoDTO> ObtertMateriaisDetalhado(long orcamentoId);
    }
}
