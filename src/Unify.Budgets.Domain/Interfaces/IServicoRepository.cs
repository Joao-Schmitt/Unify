using System.Collections.Generic;
using Unify.Budgets.Domain.Entities;

namespace Unify.Budgets.Domain.Interfaces
{
    public interface IServicoRepository : IRepository<Servico>
    {
        IEnumerable<Servico> ObterTodos();
    }
}
